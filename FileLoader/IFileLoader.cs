namespace FileLoader
{
    public interface IFileLoader
    {
        bool FileExistsInStorage(); 
        void LoadFileInStorage(); 
    }
}
