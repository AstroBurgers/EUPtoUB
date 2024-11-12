use crate::file_parsing::file_parsing::parse_file;
use crate::file_writing::write_entry_to_xml;

mod file_parsing;
mod file_writing;

fn main() {
    println!("Welcome! Enter any letter to continue...");
    press_any_key_to_continue();
    println!("Continuing!");
    let file_path = "./plugins/EUP/wardrobe.ini";
    match parse_file(file_path) {
        Ok(entries) => {
            for entry in entries {
                println!("{:?}", entry);
                write_entry_to_xml("./plugins/EUP/", &entry).unwrap()
            }
        }
        Err(err) => println!("Error: {}", err)
    }
    println!("wardrobe.ini Conversion complete! Exiting shortly...");
    std::thread::sleep(std::time::Duration::from_millis(3500));
}

fn press_any_key_to_continue() {
    use std::io::{self, Read};
    let _ = io::stdin().read(&mut [0u8]).unwrap();
}
