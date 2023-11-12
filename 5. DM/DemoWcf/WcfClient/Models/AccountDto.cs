namespace WcfClient.Models
{
    public class AccountDto
    {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Fullname { get; set; }
        public override string ToString()
        {
            return "Id: "+this.Id+"\nName: "+this.Fullname+"\nEmail: "+this.Email+"\nPassword: "+this.Password;
        }
    }
}
