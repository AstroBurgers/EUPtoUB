pub mod file_parsing {
    use std::{io};
    use std::io::{BufRead, BufReader};
    use std;
    use std::collections::HashMap;
    use std::fs::File;

    #[derive(Debug)]
    pub struct Attribute {
        pub item_id: i32,
        pub texture_id: i32,
    }

    #[derive(Debug)]
    pub struct Entry {
        pub title: String,
        pub gender: Option<String>,  // Add gender field
        pub attributes: HashMap<String, Attribute>,
    }

    pub fn parse_file(file_path: &str) -> io::Result<Vec<Entry>> {
        let file = File::open(file_path)?;
        let buff_reader = BufReader::new(file);

        let mut entries = Vec::new();
        let mut current_entry: Option<Entry> = None;

        for line in buff_reader.lines() {
            let line = line?.trim().to_string();
            if line.is_empty() {
                continue;
            }

            // Debug: Print the current line being processed
            println!("Processing line: {}", line);

            // Check for section header (new entry start)
            if line.starts_with("[") && line.ends_with("]") {
                // If an entry is already being processed, add it to entries before starting a new one
                if let Some(entry) = current_entry.take() {
                    println!("Adding entry: {:?}", entry);  // Debug statement
                    entries.push(entry);
                }

                // Start a new entry with the header as the title
                let title = line[1..line.len() - 1].to_string();
                println!("Starting new entry: {}", title);  // Debug statement
                current_entry = Some(Entry {
                    title,
                    gender: None,  // Initialize gender as None
                    attributes: HashMap::new(),
                });
            } else if let Some((key, value)) = line.split_once('=') {
                let key = key.trim().to_string();
                let value = value.trim().to_string();

                if key == "Gender" {
                    // If the line contains a gender, set it for the current entry
                    if let Some(entry) = current_entry.as_mut() {
                        println!("Setting gender: {}", value);  // Debug statement
                        entry.gender = Some(value.clone());
                    }
                } else {
                    // Parse other attributes
                    let value_parts: Vec<&str> = value.split(':').collect();
                    if value_parts.len() == 2 {
                        if let (Ok(item_id), Ok(texture_id)) = (value_parts[0].parse::<i32>(), value_parts[1].parse::<i32>()) {
                            if let Some(entry) = current_entry.as_mut() {
                                println!("Adding attribute {} with item_id: {} and texture_id: {}", key, item_id, texture_id);  // Debug statement
                                entry.attributes.insert(
                                    key,
                                    Attribute { item_id, texture_id },
                                );
                            }
                        }
                    }
                }
            }
        }

        // After the loop, push the last entry if it exists
        if let Some(entry) = current_entry {
            println!("Adding final entry: {:?}", entry);  // Debug statement
            entries.push(entry);
        }

        Ok(entries)
    }
}