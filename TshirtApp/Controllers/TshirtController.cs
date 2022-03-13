using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tshirt.API.ViewModels;
using Tshirt.Entities.Entities;
using Tshirt.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace Tshirt.API.Controllers
{
    [ApiController]
    public class TshirtController : ControllerBase
    {
        private ITshirtService tshirtService;
        public TshirtController(ITshirtService TshirtService)
        {
            tshirtService = TshirtService;
        }
        [HttpGet]
        [Route("api/[controller]/GetTshirts")]
        public IActionResult GetTshirts()
        {
            var tshirts = tshirtService.GetAll().Select(x => new TshirtListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                NumberOfColor = x.TshirtImages.GroupBy(x => x.ColorId).Count(),
                NumberOfFabric = x.TshirtImages.GroupBy(x => x.FabricId).Count(),
                NumberOfImage = x.TshirtImages.Where(x => x.ImagePath != null).Count(),
            }).ToList();

            return Ok(tshirts);
        }

        [HttpGet]
        [Route("api/[controller]/GetTshirtById/{id}")]
        public IActionResult GetTshirtById(int id)
        {
            var tshirt = tshirtService.GetTshirtById(id);
            var tshirtImages = tshirtService.GetTshirtImagesById(id);
            var colors = tshirtService.GetEnmColors();
            var fabrics = tshirtService.GetEnmFabrics();

            List<EnumViewModel> listOfColors = new List<EnumViewModel>();
            List<EnumViewModel> listOfFabrics = new List<EnumViewModel>();
            List<TshirtImageViewModel> listOfTshirts = new List<TshirtImageViewModel>();
            List<TshirtEditViewModel> tshirtList = new List<TshirtEditViewModel>();


            foreach (var color in colors)
            {
                listOfColors.Add(new EnumViewModel() { Id = color.Id, Value = color.Value });
            }

            foreach (var fabric in fabrics)
            {
                listOfFabrics.Add(new EnumViewModel() { Id = fabric.Id, Value = fabric.Value });
            }

            foreach (var item in tshirtImages)
            {
                var tshirtImageViewModel = new TshirtImageViewModel()
                {
                    Id = item.Id,
                    TshirtId = item.TshirtId,
                    ImagePath = item.ImagePath,
                    Name = item.Tshirt.Name,
                    ColorId = item.ColorId,
                    FabricId = item.FabricId
                };

                listOfTshirts.Add(tshirtImageViewModel);
            }

            var tshirtEditViewModel = new TshirtEditViewModel()
            {
                TshirtId= tshirt.Id,
                Name= tshirt.Name,
                Colors = listOfColors,
                Fabrics = listOfFabrics,
                TshirtImages = listOfTshirts
            };

            tshirtList.Add(tshirtEditViewModel);

            return Ok(tshirtList);
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteImageById/{id}")]
        public IActionResult DeleteImageById(int id)
        {
            tshirtService.DeleteImage(id);
            return Ok();
        }

        [HttpPost()]
        [Route("api/[controller]/AddImage")]
        public IActionResult AddImage([FromForm]ImageViewModel imageViewModel)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            var fileExtension = Path.GetExtension(imageViewModel.Image.FileName);
            var fileName = imageViewModel.Image.FileName + "_" + Guid.NewGuid() +fileExtension;
            imageViewModel.ImagePath = Path.Combine("Images/", fileName);
            
            List<string> PermittedFileTypes = new List<string> {
                "image/jpeg",
                "image/png",
                "image/jpg"
              };


            if (PermittedFileTypes.Contains(imageViewModel.Image.ContentType))
            {
                using (var stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                {
                     imageViewModel.Image.CopyToAsync(stream);
                }

                var tshirtEntity = new TshirtImage()
                {
                    ColorId = imageViewModel.ColorId,
                    FabricId = imageViewModel.FabricId,
                    ImagePath = imageViewModel.ImagePath,
                    TshirtId = imageViewModel.TshirtId
                };
                tshirtService.AddImage(tshirtEntity);

            }

            return Ok();
        }
    }
}
