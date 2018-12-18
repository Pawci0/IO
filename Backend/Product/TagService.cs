using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using System.Threading.Tasks;

namespace Product
{
    public class TagService
    {
        private DBManager db;

        public TagService()
        {
            db = new DBManager();
        }

        public TagDto GetTag(int id)
        {
            Database.Tag tag = db.GetTagById(id);
            if (tag != null)
            {
                return new TagDto(tag.Tag_Id, tag.Name);
            }
            return null;
        }

        public void CreateTag(TagDto tag)
        {
            db.CreateTag(tag.tagId, tag.name);
        }

        public void UpdateTag(TagDto tag)
        {
            db.UpdateTagById(tag.tagId, tag.name);
        }

        public void DeleteTag(int id)
        {
            db.DeleteTagById(id);
        }
    }
}
