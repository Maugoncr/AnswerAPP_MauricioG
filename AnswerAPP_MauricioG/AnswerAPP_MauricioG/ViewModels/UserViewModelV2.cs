using AnswerAPP_MauricioG.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnswerAPP_MauricioG.ViewModels
{
    public class UserViewModelV2 : BaseViewModel
    {
        // a diferencia del primer vm para usuario, este será adecuado para
        //realizar el binding a cada control en la vista

        //con respecto a las propiedades debemos usar el formato FULL PROP
        //ya que debemos implementar OnPropertyChange
        //(cuya funcionalidad se hereda de BaseViewModel)

        // El Binding entre los controles de la vista y las propiedades del ViewModel
        //ocurren en "tiempo real" al modificar los datos en la vista.
        // para que esto ocurra OnPropChange en el get: o en el set;
        // de la propiedad.


        private string nombreDeUsuario;
        private string nombre;
        private string apellido;
        private string numeroTelefono;
        private string contraseniaUsuario;
        private int contadorAdvertencias;
        private string correoRespaldo;
        private string descripcionTrabajo;
        private int estadoUsuarioID;
        private int paisID;
        private int rolUsuarioID;

        public User MiUsuario { get; set; }

        public Tools.Crypto MiEncriptador { get; set; }

        public string NombreDeUsuario
        {
            get { return nombreDeUsuario; }
            set
            {
                if (nombreDeUsuario == value)
                {
                    return;
                }
                nombreDeUsuario = value;
                OnPropertyChanged(nameof(NombreDeUsuario));
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (nombre == value)
                {
                    return;
                }
                nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (apellido == value)
                {
                    return;
                }
                apellido = value;
                OnPropertyChanged(nameof(Apellido));
            }
        }
        public string NumeroTelefono
        {
            get { return numeroTelefono; }
            set
            {
                if (numeroTelefono == value)
                {
                    return;
                }
                numeroTelefono = value;
                OnPropertyChanged(nameof(NumeroTelefono));
            }
        }
        public string ContraseniaUsuario
        {
            get { return contraseniaUsuario; }
            set
            {
                if (contraseniaUsuario == value)
                {
                    return;
                }
                contraseniaUsuario = value;
                OnPropertyChanged(nameof(ContraseniaUsuario));
            }
        }

        public int ContadorAdvertencias
        {
            get { return contadorAdvertencias; }
            set
            {
                if (contadorAdvertencias == value)
                {
                    return;
                }
                contadorAdvertencias = value;
                OnPropertyChanged(nameof(ContadorAdvertencias));
            }
        }
        public string CorreoRespaldo
        {
            get { return correoRespaldo; }
            set
            {
                if (correoRespaldo == value)
                {
                    return;
                }
                correoRespaldo = value;
                OnPropertyChanged(nameof(CorreoRespaldo));
            }
        }
        public string DescripcionTrabajo
        {
            get { return descripcionTrabajo; }
            set
            {
                if (descripcionTrabajo == value)
                {
                    return;
                }
                descripcionTrabajo = value;
                OnPropertyChanged(nameof(DescripcionTrabajo));
            }
        }
        public int EstadoUsuarioID
        {
            get { return estadoUsuarioID; }
            set
            {
                if (estadoUsuarioID == value)
                {
                    return;
                }
                estadoUsuarioID = value;
                OnPropertyChanged(nameof(EstadoUsuarioID));
            }
        }
        public int PaisID
        {
            get { return paisID; }
            set
            {
                if (paisID == value)
                {
                    return;
                }
                paisID = value;
                OnPropertyChanged(nameof(PaisID));
            }
        }
        public int RolUsuarioID
        {
            get { return rolUsuarioID; }
            set
            {
                if (rolUsuarioID == value)
                {
                    return;
                }
                rolUsuarioID = value;
                OnPropertyChanged(nameof(RolUsuarioID));
            }
        }

        public Command AgregarUsuarioCommand { get; }


        public UserViewModelV2()
        {
            MiUsuario = new User();
            MiEncriptador = new Tools.Crypto();

            //Implementacion de los Command

            AgregarUsuarioCommand = new Command(async () => await
            AgregarUsuario(NombreDeUsuario,
                           Nombre,Apellido,
                           NumeroTelefono,
                           ContraseniaUsuario,
                           CorreoRespaldo,
                           DescripcionTrabajo, 1,1,1));


        }

        //A diferencia del vm original, acá definimos las acciones por medio de Command(s)
        //Si la funcionalidad es muy compleja y requiere de un manejo mas detallado, igual se puede
        // usar como lo vimos en el vm original


        //escribimos las funciones de forma similar (sino identica) a la version original del vm

        // Agregamos una funcion para AGREGAR el usuario

        public async Task<bool> AgregarUsuario(string pUserName,
                                        string pFirstName,
                                        string pLastName,
                                        string pPhoneNumber,
                                        string pUserPassword,
                                        string pBackUpEmail,
                                        string pJobDescription,
                                        int pUserStatusId = 1,
                                        int pCountryId = 1,
                                        int pUserRoleId = 1)
        {

            if (IsBusy) return false;

            IsBusy = true;

            try
            {


                MiUsuario.UserName = pUserName;
                MiUsuario.FirstName = pFirstName;
                MiUsuario.LastName = pLastName;
                MiUsuario.PhoneNumber = pPhoneNumber;

                string EncriptedPassword = MiEncriptador.EncriptarEnUnSentido(pUserPassword);

                MiUsuario.UserPassword = EncriptedPassword;
                MiUsuario.BackUpEmail = pBackUpEmail;
                MiUsuario.JobDescription = pJobDescription;
                MiUsuario.UserStatusId = pUserStatusId;
                MiUsuario.CountryId = pCountryId;
                MiUsuario.UserRoleId = pUserRoleId;

                //este objeto compuesto es funcional para la carga del picker de roles de usuario
                //TODO: Deberia ser cargado con la informacion del ROl seleccionado en el Picker
                //Ver video que se adjunta para entender como se administra el role seleccionado en un picker
                //https://www.youtube.com/watch?v=WJ0FzP2bYMQ

                MiUsuario.UserRole = null;



                //MiUsuario.UserRole.UserRoleId = pUserRoleId;
                ////opcional
                //MiUsuario.UserRole.UserRole1 = "Role";

                MiUsuario.StrikeCount = 0;

                bool R = await MiUsuario.AddNewUser();

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {

                IsBusy = false;

            }
        }




    }
}
