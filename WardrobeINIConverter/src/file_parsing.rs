mod file_parsing{
    use std::fs;
    use std::io::{BufRead, BufReader, Lines};
    use std;
    use std::collections::HashMap;
    use std::fs::File;

    struct IniRead{
        name: String,
        content: LineData,
    }

    impl IniRead {
        pub fn start_parse(){
            let file_path = "WardrobeINIConverter/plugins/EUP/wardrobe.ini";
            let buff_reader = BufReader::new(fs::File::open(file_path)).lines()?;
            for line in buff_reader{
                let
                let lineData = IniRead{
                    name:
                };
            }


        }


    }

    struct LineData{
        comp_name: String,
        data: HashMap<i16, i16>
    }
}