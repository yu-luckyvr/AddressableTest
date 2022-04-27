﻿using UnityEngine;

namespace VrGamesDev
{
    /// <summary>
    /// Handle and encapsulate the session data, persistant over the game sessions
    /// The class can be used without instantiationm and will use sufixes to know
    /// what data is from VrGamesDev packages from other software
    /// For more information: <a href="https://docs.unity3d.com/ScriptReference/PlayerPrefs.html">Unity PlayerPrefs</a>
    /// </summary>
    public class VRG_Session : VRG_Base
    {
        /// <summary>
        /// The Main sufix of all the date of VrGamesDev Package
        /// </summary>
        [Tooltip("The Main sufix of all the date of VrGamesDev Package")]
        [SerializeField] public static string m_Sufix = "VrGamesDev";

        /// <summary>
        /// The Main separator from an Object and its data
        /// </summary>
        [Tooltip("The Main separator from an Object and its data")]
        [SerializeField] public static string m_Separation = " | ";

        /// <summary>
        /// The Main sufix of all the data of VrGamesDev Package
        /// </summary>
        [Tooltip("The Main sufix of all the data of VrGamesDev Package")]
        [SerializeField] public static string m_Class = " : ";


        /*
        [Header("FROM Debug:  - DO NOT EDIT unless you understand what is going on - ")]
        /// <summary>
        /// Just Save in case it was modified
        /// </summary>
        [Tooltip("Just Save in case it was modified")]
        //[SerializeField]
        public static bool m_IsModified = true;
        */

        /// <summary>
        /// Singleton pattern, Instance is the variable that hold the data in case of instantiating.
        /// </summary>
        public static VRG_Session Instance;

        /// Singleton pattern
        /// #IGNORE
        private void Awake()
        {
            // reviso si soy el primero
            if (Instance == null)
            {
                // ... como lo soy, me hago el bueno
                Instance = this;

                // i follow my own rules
                this.transform.SetParent(null);

                // y no me destruyo
                DontDestroyOnLoad(this);
            }
            else
            {
                // como no lo soy, me voy
                Destroy(this.gameObject);
            }
        }





        /// <summary>
        /// Get the session name, it uses the suffix and separation and all the data to save.
        /// </summary>
        /// <param name="sObjectLocal">The Object owner of the data</param>
        /// <param name="sDataLocal">The data to query</param>
        /// <returns>The string of the session</returns>
        public static string SessionName(string sObjectLocal, string sDataLocal)
        {
            // build the name of session
            string sNameToSession = m_Sufix + m_Separation + sObjectLocal + m_Class + sDataLocal;

            // return the session's name
            return sNameToSession.Trim();
        }


        /// <summary>
        /// Query a string from the persistant data
        /// </summary>
        /// <param name="sObjectLocal">The object to query</param>
        /// <param name="sDataLocal">The data of the object</param>
        /// <returns>The string queried</returns>
        //public static string String(string sObjectLocal, string sDataLocal) => VRG_Session.GetString(sObjectLocal, sDataLocal);
        public static string GetString(string sObjectLocal, string sDataLocal)
        {
            // armar el nombre de la variable que solicitan y le agrego el sufijo
            string sNameToSession = SessionName(sObjectLocal, sDataLocal);

            // se asigna el valor
            return PlayerPrefs.GetString(sNameToSession).Trim();
        }



        /// <summary>
        /// Overloaded funtion: Save the string sent in the <strong>valueLocal</strong> Data into the persistant data
        /// </summary>
        /// <param name="sObjectLocal">The object to query</param>
        /// <param name="sDataLocal">The data of the object</param>
        /// <param name="valueLocal">The value of the string to save</param>
        //public static void String(string sObjectLocal, string sDataLocal, string valueLocal) => VRG_Session.SetString(sObjectLocal, sDataLocal, valueLocal);
        public static void SetString(string sObjectLocal, string sDataLocal, string valueLocal)
        {
            // armar el nombre de la variable que solicitan y le agrego el sufijo
            string sNameToSession = SessionName(sObjectLocal, sDataLocal);

            // se asigna el valor
            PlayerPrefs.SetString(sNameToSession, valueLocal);
        }
















        /// <summary>
        /// Query a float from the persistant data
        /// </summary>
        /// <param name="sObjectLocal">The object to query</param>
        /// <param name="sDataLocal">The data of the object</param>
        /// <returns>The float queried</returns>
        //public static float Float(string sObjectLocal, string sDataLocal) => VRG_Session.GetFloat(sObjectLocal, sDataLocal);
        public static float GetFloat(string sObjectLocal, string sDataLocal)
        {
            // armar el nombre de la variable que solicitan y le agrego el sufijo
            string sNameToSession = SessionName(sObjectLocal, sDataLocal);

            // se regresa el valor
            return PlayerPrefs.GetFloat(sNameToSession, 0.0f);
        }

        /// <summary>
        /// Overloaded funtion: Save the float sent in the <strong>valueLocal</strong> Data into the persistant data
        /// </summary>
        /// <param name="sObjectLocal">The object to query</param>
        /// <param name="sDataLocal">The data of the object</param>
        /// <param name="valueLocal">The value of the float to save</param>
        //public static void Float(string sObjectLocal, string sDataLocal, float valueLocal) => VRG_Session.SetFloat(sObjectLocal, sDataLocal, valueLocal);
        public static void SetFloat(string sObjectLocal, string sDataLocal, float valueLocal)
        {
            // armar el nombre de la variable que solicitan y le agrego el sufijo
            string sNameToSession = SessionName(sObjectLocal, sDataLocal);

            // se asigna el valor
            PlayerPrefs.SetFloat(sNameToSession, valueLocal);
        }





        /// #IGNORE
        public static bool GetBool(string sObjectLocal, string sDataLocal)
        {
            return VRG_Session.GetBool(sObjectLocal, sDataLocal, false);
        }

        /// <summary>
        /// Query a bool from the persistant data, if the data doesn't exist previously
        /// the valueLocal
        /// </summary>
        /// <param name="sObjectLocal">The object to query</param>
        /// <param name="sDataLocal">The data of the object</param>
        /// <param name="valueLocal">(Optional) By default is false</param>
        /// <returns>The bool value queried</returns>
        public static bool GetBool(string sObjectLocal, string sDataLocal, bool valueLocal)
        {
            // armar el nombre de la variable que solicitan y le agrego el sufijo
            string sNameToSession = SessionName(sObjectLocal, sDataLocal);

            // se regresa el valor
            int value = PlayerPrefs.GetInt(sNameToSession, valueLocal ? 1 : 0);

            if (value == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Overloaded funtion: Save the bool sent in the <strong>valueLocal</strong> into the persistant data
        /// </summary>
        /// <param name="sObjectLocal"></param>
        /// <param name="sDataLocal"></param>
        /// <param name="valueLocal"></param>
        public static void SetBool(string sObjectLocal, string sDataLocal, bool valueLocal)
        {
            // armar el nombre de la variable que solicitan y le agrego el sufijo
            string sNameToSession = SessionName(sObjectLocal, sDataLocal);

            // assign value
            PlayerPrefs.SetInt(sNameToSession, valueLocal ? 1 : 0);
        }







        /// <summary>
        /// Query am Int from the persistant data
        /// </summary>
        /// <param name="sObjectLocal">The object to query</param>
        /// <param name="sDataLocal">The data of the object</param>
        /// <returns>The Int queried</returns>
        //public static int Int(string sObjectLocal, string sDataLocal) => VRG_Session.GetInt(sObjectLocal, sDataLocal);
        public static int GetInt(string sObjectLocal, string sDataLocal)
        {
            int iReturn = 0;

            // armar el nombre de la variable que solicitan y le agrego el sufijo
            string sNameToSession = SessionName(sObjectLocal, sDataLocal);

            if (PlayerPrefs.HasKey(sNameToSession))
            {
                iReturn = PlayerPrefs.GetInt(sNameToSession, iReturn);
            }
            else
            {
                VRG_Session.SetInt(sObjectLocal, sDataLocal, iReturn);
            }

            // se regresa el valor
            return iReturn;
        }

        /// <summary>
        /// Overloaded funtion: Save the Int sent in the <strong>valueLocal</strong> Data into the persistant data
        /// </summary>
        /// <param name="sObjectLocal">The object to query</param>
        /// <param name="sDataLocal">The data of the object</param>
        /// <param name="valueLocal">The value of the Int to save</param>
        //public static void Int(string sObjectLocal, string sDataLocal, int valueLocal) => VRG_Session.SetInt(sObjectLocal, sDataLocal, valueLocal);
        public static void SetInt(string sObjectLocal, string sDataLocal, int valueLocal)
        {
            // armar el nombre de la variable que solicitan y le agrego el sufijo
            string sNameToSession = SessionName(sObjectLocal, sDataLocal);

            // se asigna en valor
            PlayerPrefs.SetInt(sNameToSession, valueLocal);
        }



        /// #IGNORE
        public static int Add(string sObjectLocal, string sDataLocal) => VRG_Session.Add(sObjectLocal, sDataLocal, 1);

        /// <summary>
        /// Overloaded funtion: Add <strong>iValueLocal</strong> from <strong>sDataLocal</strong> into the persistant data
        /// By default it is +1
        /// </summary>
        /// <param name="sObjectLocal">The object to query</param>
        /// <param name="sDataLocal">The data of the object</param>
        /// <param name="iValueLocal">(Optional) By default is 1</param>
        /// <returns>The result number added to the previous data</returns>
        public static int Add(string sObjectLocal, string sDataLocal, int iValueLocal)
        {
            // armar el nombre de la variable que solicitan y le agrego el sufijo
            string sNameToSession = SessionName(sObjectLocal, sDataLocal);

            // esta es la variable que voy a regresar, la busco en la sesión, por defeault 0
            int iReturn = PlayerPrefs.GetInt(sNameToSession, 0);

            // la incremento en uno, la función se llama "Add"
            iReturn += iValueLocal;

            // la meto a la sesión ya incrementada
            PlayerPrefs.SetInt(sNameToSession, iReturn);

            // regreso el valor obtenido y sumado
            return iReturn;
        }



        /*
        // salvar los datos a disco duro, se regresa si se pudo o no
        public static bool Save()
        {
            // esta variable va a guardar si se modifico o no
            bool bReturn = false;

            // solo salvar si se ha modificado algo en la sesión
            if (m_IsModified)
            {
                // se salva a disco
                PlayerPrefs.Save();

                // se resetea la bandera de modificación
                m_IsModified = false;

                // se va a regresar que si se pudo
                bReturn = true;

                Debug.Log("<color=green><b>SAVING:</b></color> to disk");
            }
            else
            {
                Debug.Log("<color=red><b>NOT SAVING:</b></color> to disk");
            }

            // regreso el valor obtenido
            return bReturn;
        }
        */

    }
}