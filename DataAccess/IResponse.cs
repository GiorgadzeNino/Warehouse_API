namespace BTUProject
{
    public interface IResponse<T>
    {
        string Error { get; set; }
        T Data { get; set; }
    }
}
