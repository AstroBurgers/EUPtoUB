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

            if line.starts_with("[") && line.ends_with("]") {
                if let Some(entry) = current_entry.take(){
                    entries.push(entry);
                }

                let title = line[1..line.len() - 1].to_string();
                current_entry = Some(Entry{
                    title,
                    attributes: HashMap::new()
                })
            }
            else if let Some((key, value)) = line.split_once('='){
                let key = key.trim().to_string();
                let value = value.trim().to_string();
                let value_parts: Vec<&str> = value.trim().split(':').collect();

                if value_parts.len() == 2 {
                    if let (Ok(item_id), Ok(texture_id)) = (value_parts[0].parse::<i32>(), value_parts[1].parse::<i32>()){
                        if let Some(entry) = current_entry.as_mut() {
                            entry.attributes.insert(
                                key,
                                Attribute
                                {item_id, texture_id}
                            );
                        }
                    }
                }
            }
        }
        if let Some(entry) = current_entry{
            entries.push(entry);
        }

        Ok(entries)
    }
}