using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace GardenIt.Models.ViewModels
{
    public class PlantViewModel
    {
        public Guid? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        [Range(0,30)]
        public int DaysBetweenWatering { get; set; }

        [MaxLength(400)]
        public string Notes { get; set; }

        public IFormFile ImageFile { get; set; }
        public string ImageName { get; set; }
        public bool HasImage {
            get {
                return !String.IsNullOrEmpty(ImageName) && ImageName != "default.png";
            }
        }
    }
}