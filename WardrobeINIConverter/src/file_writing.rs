use std::fs::{File, OpenOptions};
use std::io::{self, Write};
use std::path::Path;
use std::collections::HashMap;
use crate::file_parsing::file_parsing::Attribute;
use crate::file_parsing::file_parsing::Entry;

fn get_attribute_value(attributes: &HashMap<String, Attribute>, key: &str) -> Option<(i32, i32)> {
    attributes.get(key).map(|attr| (attr.item_id, attr.texture_id))
}

pub fn write_entry_to_xml(output_dir: &str, entry: &Entry) -> io::Result<()> {
    // Determine Ped model name based on gender field in Entry struct
    let ped_model = match entry.gender.as_deref() {
        Some("Male") => "MP_M_FREEMODE_01",  // Male
        Some("Female") => "MP_F_FREEMODE_01",  // Female
        _ => "N/A Gender",  // Default if gender is not provided or invalid
    };

    let outfit_comment = if !entry.title.is_empty() {
        format!("<!-- {} --> ", entry.title)
    } else {
        String::new()
    };

    // Build XML string for each attribute
    let xml_content = format!(
        "{}<Ped chance=\"UPTOPLAYER\" \
            prop_glasses=\"{}\" tex_glasses=\"{}\" \
            prop_hats=\"{}\" tex_hats=\"{}\" \
            prop_ears=\"{}\" tex_ears=\"{}\" \
            comp_beard=\"{}\" tex_beard=\"{}\" \
            comp_shirtoverlay=\"{}\" tex_shirtoverlay=\"{}\" \
            comp_shirt=\"{}\" tex_shirt=\"{}\" \
            comp_decals=\"{}\" tex_decals=\"{}\" \
            comp_accessories=\"{}\" tex_accessories=\"{}\" \
            comp_pants=\"{}\" tex_pants=\"{}\" \
            comp_shoes=\"{}\" tex_shoes=\"{}\" \
            comp_eyes=\"{}\" tex_eyes=\"{}\" \
            comp_tasks=\"{}\" tex_tasks=\"{}\" \
            comp_hands=\"{}\" tex_hands=\"{}\">{}</Ped>",
        outfit_comment,
        get_attribute_value(&entry.attributes, "Glasses").unwrap_or((0, 0)).0,
        get_attribute_value(&entry.attributes, "Glasses").unwrap_or((0, 0)).1,
        get_attribute_value(&entry.attributes, "Hat").unwrap_or((0, 0)).0,
        get_attribute_value(&entry.attributes, "Hat").unwrap_or((0, 0)).1,
        get_attribute_value(&entry.attributes, "Ear").unwrap_or((0, 0)).0,
        get_attribute_value(&entry.attributes, "Ear").unwrap_or((0, 0)).1,
        get_attribute_value(&entry.attributes, "Beard").unwrap_or((0, 0)).0,
        get_attribute_value(&entry.attributes, "Beard").unwrap_or((0, 0)).1,
        get_attribute_value(&entry.attributes, "ShirtOverlay").unwrap_or((0, 0)).0,
        get_attribute_value(&entry.attributes, "ShirtOverlay").unwrap_or((0, 0)).1,
        get_attribute_value(&entry.attributes, "Shirt").unwrap_or((0, 0)).0,
        get_attribute_value(&entry.attributes, "Shirt").unwrap_or((0, 0)).1,
        get_attribute_value(&entry.attributes, "Decals").unwrap_or((0, 0)).0,
        get_attribute_value(&entry.attributes, "Decals").unwrap_or((0, 0)).1,
        get_attribute_value(&entry.attributes, "Accessories").unwrap_or((0, 0)).0,
        get_attribute_value(&entry.attributes, "Accessories").unwrap_or((0, 0)).1,
        get_attribute_value(&entry.attributes, "Pants").unwrap_or((0, 0)).0,
        get_attribute_value(&entry.attributes, "Pants").unwrap_or((0, 0)).1,
        get_attribute_value(&entry.attributes, "Shoes").unwrap_or((0, 0)).0,
        get_attribute_value(&entry.attributes, "Shoes").unwrap_or((0, 0)).1,
        get_attribute_value(&entry.attributes, "Eyes").unwrap_or((0, 0)).0,
        get_attribute_value(&entry.attributes, "Eyes").unwrap_or((0, 0)).1,
        get_attribute_value(&entry.attributes, "Tasks").unwrap_or((0, 0)).0,
        get_attribute_value(&entry.attributes, "Tasks").unwrap_or((0, 0)).1,
        get_attribute_value(&entry.attributes, "Hands").unwrap_or((0, 0)).0,
        get_attribute_value(&entry.attributes, "Hands").unwrap_or((0, 0)).1,
        ped_model,  // Use the determined model name
    );

    // Open file in append mode
    let output_path = Path::new(output_dir).join("convertedwardrobe.txt");
    let mut file = OpenOptions::new()
        .create(true)
        .append(true)
        .open(&output_path)?;

    // Write the XML content to file
    writeln!(file, "{}", xml_content)?;
    Ok(())
}