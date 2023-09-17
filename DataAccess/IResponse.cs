namespace BTUProject.DataAccess
{
    public interface IResponse<T>
    {
        string Error { get; set; }
        T Data { get; set; }
    }
}
