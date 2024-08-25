namespace _01_04_1_SignalREjemplosVarios.Model
{
    public class Usuario
    {
        public String Email { get; set; }
        public String Password { get; set; }


        public Usuario(String email, String pass) {
            this.Email = email;
            this.Password = pass;
        }

        public Boolean EsUsuarioValido()
        {
            //TODO implementar lógica de autenticacion
            return true;
        }

        public Boolean NecesitarVerificacion()
        {
            //TODO implmentar lógica de verificación
            return true; 
        }

    }
}
