using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SearchSnippet.Models
{
    [Serializable]
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Created
        {
            get
            {
                if (!_created.HasValue) this._created = DateTime.Now;
                return this._created.Value;
            }
            set
            {
                this._created = value;
            }
        }

        public virtual ICollection<Product> Products { get; set; }

        private DateTime? _created { get; set; }
    }
}