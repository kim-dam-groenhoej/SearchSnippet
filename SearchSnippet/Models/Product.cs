using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SearchSnippet.Models
{
    [Serializable]
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Created {
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

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        [NotMapped]
        public bool IsInStock
        {
            get
            {
                return this.Amount > 0;
            }
        }

        private DateTime? _created { get; set; }
    }
}