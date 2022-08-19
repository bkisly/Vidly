namespace Vidly.Models.DataTransferObjects
{
    public interface IDataTransferObject<T>
    {
        public T ConvertToModel();
    }
}
