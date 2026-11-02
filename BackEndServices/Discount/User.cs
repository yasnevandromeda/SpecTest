namespace BackEndServices
{
    public class User
    {
        public User(long userID, bool isGraduate)
        {
            UserID = userID;
            IsGraduate = isGraduate;
        }

        public long UserID { get; set; }

        public bool IsGraduate { get; set; }
    }
}
