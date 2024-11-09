use crate::file_parsing::file_parsing::parse_file;

mod file_parsing;

fn main() {
    println!("Welcome! Enter any letter to continue...");
    press_any_key_to_continue();
    println!("Continuing!");
    let file_path = "./plugins/EUP/wardrobe.ini";
    match parse_file(file_path) {
        Ok(entries) => {
            for entry in entries {
                println!("{:?}", entry)
            }
        }
        Err(err) => println!("Error: {}", err)
    }
}

fn press_any_key_to_continue() {
    use std::io::{self, Read};
    let _ = io::stdin().read(&mut [0u8]).unwrap();
}
