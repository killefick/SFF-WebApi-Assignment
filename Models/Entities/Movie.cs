using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SFF.Models
{
    public class Movie : BaseEntity
    {

        private Movie()
        {
            // for EF only
        }

        public Movie(string title, int amountInStock)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title is required");
            }

            else if (amountInStock < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid amount");
            }

            this.Title = title;
            this.AmountInStock = amountInStock;
        }

        [Required]
        [MaxLength (50)]
        public string Title { get; private set; }
        public byte[] CoverPicture { get; private set; }
        [Required]
        [MaxLength (4)]
        public int AmountInStock { get; private set; }

        // one to one relationship
        // reference navigation property
        public EtikettData etikettData { get; set; }

        #region public Methods
        public bool IsAvailable()
        {
            return (this.AmountInStock > 0) ? true : false;
        }

        public Movie DecreaseAmount()
        {
            this.AmountInStock -= 1;
            return this;
        }

        public Movie IncreaseAmount()
        {
            this.AmountInStock += 1;
            return this;
        }
        #endregion
    }
}