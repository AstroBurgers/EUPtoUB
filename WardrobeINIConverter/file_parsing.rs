mod file_parsing{
    use std::io;
    use std::io::prelude::*;
    use std::io::BufReader;
    use std::fs::File;

    fn parse_wardrobe() -> io::Result<()> {
        let reader = BufReader::new(File::open("./plugins/EUP/wardrobe.ini")?).lines();


    }

    pub struct IniParser<R: Read>{
        lines: Lines<BufReader<R>>,
        kv: HashMap<String, String>
    }

    impl<R: Read> IniParser<R> {
        pub fn parse(reader: R) -> IniParser<R> {
            let mut parser = IniParser{
                lines,
                kv: HashMap::new()
            };
            
            while let Some(Ok(line)) = parser.lines.next() {
                parser.parse_line(&mut line.chars().peekable())?;
            }

            Ok(parser.kv)
        }
    }
}