using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WisdomPrototype.Models
{
    public enum Genre { Proverb, Quote, Insight, Musing, Video}
    public class Wisdom
    {
        [Key]
        public int WisdomId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public Genre GenreOfWisdom { get; set; }
        [Required]
        [ForeignKey("Author")]
        public int  AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }

    public class WisdomContext : DbContext
    {
        public DbSet<Wisdom> WisdomSet { get; set; }
        public DbSet<Author> AuthorSet { get; set; }
    }
}