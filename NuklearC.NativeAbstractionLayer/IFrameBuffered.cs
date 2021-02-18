namespace NuklearC.NativeAbstractionLayer
{
    public interface IFrameBuffered
    {
        void BeginBuffering();
        void EndBuffering();
        void RenderFinal();
    }
}