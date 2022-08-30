namespace back_Fluxi.Interfaces
{
    public interface IUpload
    {
        public string UploadImg(IFormFile file);

        public string UploadVideo(IFormFile file);
    }
}
