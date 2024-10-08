using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDB_Preview.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; } = null!;

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; } = null!;

        [MaxLength(50)]
        [Required]
        public string City { get; set; } = null!;

        [MaxLength(100)]
        public string? OrganizationName { get; set; }

        [Column(TypeName = "date")]
        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(300)]
        public string? About { get; set; }

        [MaxLength(100)]
        public string? SponsorName { get; set; }

        public bool IsAdmin { get; set; } = false;

        public ICollection<UserRole>? UserRoles { get; set; }

    }

    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; } = null!;

    }

    public class UserRole
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; } = null!;
    }

    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = null!;
    }


    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Title { get; set; } = null!;

        [MaxLength(255)]
        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime EventDate { get; set; }

        [MaxLength(100)]
        [Required]
        public string Location { get; set; } = null!;

        public int OrganizerId { get; set; }

        [ForeignKey(nameof(OrganizerId))]
        public User User { get; set; } = null!;

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

    }

    #region Event Ref

    public class Participant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User User { get; set; } = null!;

        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; } = null!;


        //[MaxLength(50)]
        //public string RoleInEvent { get; set; }
    }

    public class Sponsor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int SponsorId { get; set; }

        [ForeignKey(nameof(SponsorId))]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User User { get; set; } = null!;

        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; } = null!;

    }

    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; } = null!;

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User User { get; set; } = null!;

        [MaxLength(255)]
        [Required]
        public string Text { get; set; } = null!;

        [Required]
        public DateTime DateCreated { get; set; }
    }

    public class Rating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; } = null!;

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User User { get; set; } = null!;

        [Required]
        public byte RatingValue { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }

    public class Statistic
    {
        [Key]
        public int Id { get; set; }
       
        [ForeignKey(nameof(Id))]
        public Event Event { get; set; }= null!;    
        public int TotalVisits { get; set; }
        public float AverageRating { get; set; }
    }

    #endregion

    public class Favorite
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }


        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Event Event { get; set; } = null!;

    }



}
