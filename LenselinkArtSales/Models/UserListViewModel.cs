namespace LenselinkArtSales.Models
{
    public class UserListViewModel
    {
        public List<User> Users { get; set; }
        public List<SecurityRole> securityRoles { get; set; }
        public List<SecurityQuestion> securityQuestions { get; set; }
    }
}
