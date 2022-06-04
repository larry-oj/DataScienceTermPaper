namespace Etl.Services;

public interface IStageManipulator<in T>
{
    void UploadNew();
    void Update(T updatedItem);
}