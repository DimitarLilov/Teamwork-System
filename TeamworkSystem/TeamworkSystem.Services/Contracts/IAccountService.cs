namespace TeamworkSystem.Services.Contracts
{
    public interface IAccountService
    {
        void CreateStudent(string userId);

        void SetProfileImage(string userId);
    }
}
