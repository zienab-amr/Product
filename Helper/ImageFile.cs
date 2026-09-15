namespace Product.Helper
{
    public class ImageFile
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            string folderPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                folderName);

            string fileName = Guid.NewGuid().ToString()
                + Path.GetExtension(file.FileName);

            string filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }

    }
}
