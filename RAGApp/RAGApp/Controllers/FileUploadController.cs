// RAGApp/Controllers/FileUploadController.cs

using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace RAGApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FileUploadController : ControllerBase
	{
		private readonly string _uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

		public FileUploadController()
		{
			// Ensure the upload directory exists
			if (!Directory.Exists(_uploadDirectory))
			{
				Directory.CreateDirectory(_uploadDirectory);
			}
		}

		[HttpPost("upload")]
		public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
		{
			if (file == null || file.Length == 0)
			{
				return BadRequest("File upload failed: file is empty.");
			}

			var filePath = Path.Combine(_uploadDirectory, file.FileName);

			// Save the file to the uploads directory
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			return Ok(new { FilePath = filePath });
		}
	}
}
