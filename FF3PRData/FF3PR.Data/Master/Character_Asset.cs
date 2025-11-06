using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF3PR.Data.Master
{
    public class Character_Asset
    {
        public Character_Asset(Character_Asset character_Asset)
        {
            id = character_Asset.id;
            character_id = character_Asset.character_id;
            job_id = character_Asset.job_id;
            asset_type = character_Asset.asset_type;
            asset_name = character_Asset.asset_name;
            size_type = character_Asset.size_type;
            field_character_asset_id = character_Asset.field_character_asset_id;
        }

        public Character_Asset() { }

        public int id {  get; set; }
        public int character_id { get; set; }
        public int job_id { get; set; }
        public int asset_type { get; set; }
        public string? asset_name { get; set; }
        public int size_type { get; set; }
        public int field_character_asset_id { get; set; }
    }
}
