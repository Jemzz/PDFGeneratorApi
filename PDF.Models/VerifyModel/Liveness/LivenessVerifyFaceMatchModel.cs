namespace PDF.Models.VerifyModel.Liveness
{
    public class LivenessVerifyFaceMatchModel
    {
        public string Status { get; set; }
        public string Title { get; set; }
        public LivenessImagesModel SelfiePhoto { get; set; }
        public LivenessImagesModel ChipPhoto { get; set; }
        public LivenessImagesModel IdPhoto { get; set; }
    }
}
