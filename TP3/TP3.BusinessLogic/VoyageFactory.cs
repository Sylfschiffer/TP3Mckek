﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP3.BusinessLogic
{
    public class VoyageFactory
    {
        public static void Save(string connexionString, Voyage voyage)
        {
            MySqlConnection connexion = null;

            try
            {
                connexion = new MySqlConnection(connexionString);
                connexion.Open();

                MySqlCommand command = connexion.CreateCommand();
                command.Parameters.Add(new MySqlParameter("@IdConducteur", voyage.IdConducteur));
                command.Parameters.Add(new MySqlParameter("@Prix", voyage.Prix));
                command.Parameters.Add(new MySqlParameter("@Depart", voyage.Depart));
                command.Parameters.Add(new MySqlParameter("@Destination", voyage.Destination));
                command.Parameters.Add(new MySqlParameter("@HeureDepart", voyage.HeureDepart));
                command.Parameters.Add(new MySqlParameter("@Animaux", voyage.Animaux));
                command.Parameters.Add(new MySqlParameter("@Fumeur", voyage.Fumeur));
                command.Parameters.Add(new MySqlParameter("@BienEquipe", voyage.BienEquipe));
                command.Parameters.Add(new MySqlParameter("@NbPassagers", voyage.NbPassagers));

                command.CommandText = ("INSERT INTO voyage (IDConducteur, prix, depart, destination, heureDepart, animaux, fumeur, bienEquipe, nbPassagers)" + 
                    "VALUES (@IDConducteur, @Prix, @Depart, @Destination, @HeureDepart, @Animaux, @Fumeur, @BienEquipe, @NbPassagers)");
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connexion != null)
                    connexion.Close();
            }
        }

        public static Voyage[] GetByIDConducteur(string connexionString, int idConducteur)
        {
            List<Voyage> voyages = new List<Voyage>();

            MySqlConnection connexion = null;
            MySqlDataReader mySqlDataReader = null;

            try
            {
                connexion = new MySqlConnection(connexionString);
                connexion.Open();

                MySqlCommand command = connexion.CreateCommand();
                
                command.Parameters.Add(new MySqlParameter("@IDConducteur", idConducteur));

                command.CommandText = "SELECT * FROM voyage WHERE IDConducteur = @IDConducteur";
                mySqlDataReader = command.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    int id = int.Parse(mySqlDataReader["ID"].ToString());
                    int lIdConducteur = int.Parse(mySqlDataReader["IDConducteur"].ToString());
                    double prix = double.Parse(mySqlDataReader["prix"].ToString());
                    string lDepart = mySqlDataReader["depart"].ToString();
                    string lDestination = mySqlDataReader["destination"].ToString();
                    DateTime heureDepart = (DateTime)mySqlDataReader["heureDepart"];
                    bool lAnimaux = bool.Parse(mySqlDataReader["animaux"].ToString());
                    bool lFumeur = bool.Parse(mySqlDataReader["fumeur"].ToString());
                    bool lBienEquipe = bool.Parse(mySqlDataReader["bienEquipe"].ToString());
                    int nbPassagers = int.Parse(mySqlDataReader["NbPassagers"].ToString());

                    voyages.Add(new Voyage(id, lIdConducteur, prix, lDepart, lDestination, heureDepart, lAnimaux, lFumeur, lBienEquipe, nbPassagers));
                }
            }
            finally
            {
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();

                if (connexion != null)
                    connexion.Close();
            }

            return voyages.ToArray();
        }

        public static Voyage GetByID(string cnnStr,int id)
        {
            Voyage voyage = null;

            MySqlConnection connexion = null;
            MySqlDataReader mySqlDataReader = null;

            try
            {
                connexion = new MySqlConnection(cnnStr);
                connexion.Open();

                MySqlCommand command = connexion.CreateCommand();

                command.Parameters.Add(new MySqlParameter("@ID", id));

                command.CommandText = "SELECT * FROM voyage WHERE ID = @ID";
                mySqlDataReader = command.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    int Id = int.Parse(mySqlDataReader["ID"].ToString());
                    int lIdConducteur = int.Parse(mySqlDataReader["IDConducteur"].ToString());
                    double prix = double.Parse(mySqlDataReader["prix"].ToString());
                    string lDepart = mySqlDataReader["depart"].ToString();
                    string lDestination = mySqlDataReader["destination"].ToString();
                    DateTime heureDepart = (DateTime)mySqlDataReader["heureDepart"];
                    bool lAnimaux = bool.Parse(mySqlDataReader["animaux"].ToString());
                    bool lFumeur = bool.Parse(mySqlDataReader["fumeur"].ToString());
                    bool lBienEquipe = bool.Parse(mySqlDataReader["bienEquipe"].ToString());
                    int nbPassagers = int.Parse(mySqlDataReader["NbPassagers"].ToString());

                    voyage = (new Voyage(Id, lIdConducteur, prix, lDepart, lDestination, heureDepart, lAnimaux, lFumeur, lBienEquipe, nbPassagers));
                }
            }
            finally
            {
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();

                if (connexion != null)
                    connexion.Close();
            }

            return voyage;
        }

        public static void UpdatePassager(string cnnStr, int nbPassager, int ID)
        {
            MySqlConnection connexion = new MySqlConnection(cnnStr);
            MySqlCommand mySqlCmd = connexion.CreateCommand();

            try
            {
                connexion.Open();
                mySqlCmd.Parameters.Add(new MySqlParameter("@Id", ID));
                mySqlCmd.Parameters.Add(new MySqlParameter("@nbPassager", nbPassager));

                mySqlCmd.CommandText = ("UPDATE voyage SET nbPassagers=@nbPassager WHERE ID=@Id");
                mySqlCmd.ExecuteNonQuery();
            }
            finally
            {
                if (connexion != null)
                    connexion.Close();
            }
        }

        public static Voyage[] GetAll (string cnnStr)
        {
            List<Voyage> voyages = new List<Voyage>();

            MySqlConnection connexion = null;
            MySqlDataReader mySqlDataReader = null;

            try
            {
                connexion = new MySqlConnection(cnnStr);
                connexion.Open();
                MySqlCommand mySqlCmd = connexion.CreateCommand();

                mySqlCmd.CommandText = "SELECT * FROM voyage ORDER BY ID";

                mySqlDataReader = mySqlCmd.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    int ID = int.Parse(mySqlDataReader["ID"].ToString());
                    int IDConducteur = int.Parse(mySqlDataReader["IDConducteur"].ToString());
                    double prix = double.Parse(mySqlDataReader["prix"].ToString());
                    string depart = mySqlDataReader["depart"].ToString();
                    string destination = mySqlDataReader["destination"].ToString();
                    DateTime heureDepart = DateTime.Parse(mySqlDataReader["heureDepart"].ToString());
                    bool fumeur = bool.Parse(mySqlDataReader["fumeur"].ToString());
                    bool animaux = bool.Parse(mySqlDataReader["animaux"].ToString());
                    bool bienEquipe = bool.Parse(mySqlDataReader["bienEquipe"].ToString());
                    int nbPassagers = int.Parse(mySqlDataReader["nbPassagers"].ToString());

                    voyages.Add(new Voyage(ID, IDConducteur, prix, depart, destination, heureDepart, animaux, fumeur, bienEquipe, nbPassagers));
                }
            }
            finally
            {
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();

                if (connexion != null)
                    connexion.Close();
            }

            return voyages.ToArray();
        }

        public static Voyage[] Search(string connexionString, bool fumeur, bool animaux, bool bienEquipe, string depart, string destination,
                                      DateTime heureDebut, DateTime heureFin)
        {
            bool isEnter = false;
            List<Voyage> voyages = new List<Voyage>();

            MySqlConnection connexion = null;
            MySqlDataReader mySqlDataReader = null;

            try
            {
                connexion = new MySqlConnection(connexionString);
                connexion.Open();

                MySqlCommand command = connexion.CreateCommand();

                command.Parameters.Add(new MySqlParameter("@Fumeur", fumeur));
                command.Parameters.Add(new MySqlParameter("@Animaux", animaux));
                command.Parameters.Add(new MySqlParameter("@BienEquipe", bienEquipe));
                command.Parameters.Add(new MySqlParameter("@Depart", depart));
                command.Parameters.Add(new MySqlParameter("@Destination", destination));
                command.Parameters.Add(new MySqlParameter("@HeureDebut", heureDebut));
                command.Parameters.Add(new MySqlParameter("@HeureFin", heureFin));

                string commandText = "SELECT * FROM voyage WHERE (animaux = @Animaux AND fumeur = @Fumeur AND bienEquipe = @BienEquipe) OR ";
                if (depart != String.Empty)
                {
                    commandText += "depart = @Depart ";
                    isEnter = true;
                }

                if (destination != String.Empty)
                {
                    if (!isEnter)
                        commandText += "destination = @Destination ";
                    else
                        commandText += "AND destination = @Destination ";
                }
                    

                DateTime nullDate = new DateTime(1, 1, 1, 0, 0, 0);
                if (heureDebut != nullDate && heureFin != nullDate)
                {
                    if (!isEnter)
                        commandText += "heureDepart BETWEEN @HeureDebut AND @HeureFin ";
                    else
                        commandText += "AND heureDepart BETWEEN @HeureDebut AND @HeureFin ";
                }
                else if (heureDebut != nullDate && heureFin == nullDate)
                {
                    if (!isEnter)
                        commandText += "heureDepart >= @HeureDebut ";
                    else
                        commandText += "AND heureDepart >= @HeureDebut ";
                }
                else if (heureDebut == nullDate && heureFin != nullDate)
                {
                    if (!isEnter)
                        commandText += "heureDepart <= @HeureFin";
                    else
                        commandText += "AND heureDepart <= @HeureFin";
                }

                command.CommandText = commandText;
                mySqlDataReader = command.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    int id = int.Parse(mySqlDataReader["ID"].ToString());
                    int idConducteur = int.Parse(mySqlDataReader["IDConducteur"].ToString());
                    double prix = double.Parse(mySqlDataReader["prix"].ToString());
                    string lDepart = mySqlDataReader["depart"].ToString();
                    string lDestination = mySqlDataReader["destination"].ToString();
                    DateTime heureDepart = (DateTime)mySqlDataReader["heureDepart"];
                    bool lAnimaux = bool.Parse(mySqlDataReader["animaux"].ToString());
                    bool lFumeur = bool.Parse(mySqlDataReader["fumeur"].ToString());
                    bool lBienEquipe = bool.Parse(mySqlDataReader["bienEquipe"].ToString());
                    int nbPassagers = int.Parse(mySqlDataReader["NbPassagers"].ToString());

                    voyages.Add(new Voyage(id, idConducteur, prix, lDepart, lDestination, heureDepart, lAnimaux, lFumeur, lBienEquipe, nbPassagers));
                }
            }
            finally
            {
                if (mySqlDataReader != null)
                    mySqlDataReader.Close();

                if (connexion != null)
                    connexion.Close();
            }

            return voyages.ToArray();
        }

        public static void Delete(string cnnStr, int id)
        {
            MySqlConnection connexion = new MySqlConnection(cnnStr);
            connexion.Open();
            MySqlCommand mySqlCmd = connexion.CreateCommand();
            mySqlCmd.Parameters.Add(new MySqlParameter("@Id", id));
            mySqlCmd.CommandText = ("DELETE FROM voyage WHERE ID=@Id");
            mySqlCmd.ExecuteNonQuery();
        }

    }
}
