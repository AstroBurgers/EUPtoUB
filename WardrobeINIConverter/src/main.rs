mod file_parsing;

fn main() {
    println!("Welcome! Enter any letter to continue...");
    press_any_key_to_continue();
    println!("Continuing!")
}

fn press_any_key_to_continue() {
    use std::io::{self, Read};
    let _ = io::stdin().read(&mut [0u8]).unwrap();
}
