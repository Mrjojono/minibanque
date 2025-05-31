using Microsoft.EntityFrameworkCore;
using minibanque.Models;

namespace minibanque.Service
{
    public class banqueService
    {
        private List<Client> clients = new List<Client>();
        private List<Compte> comptes = new List<Compte>();
        private List<CompteCourant> compteCourant = new List<CompteCourant>();

        public banqueService()
        {
            using (var context = new AppDbContext())
            {
                // Initialize the lists with data from the database
                clients = context.Clients.ToList();
                compteCourant = context.ComptesCourants.ToList();
            }
        }


        public void AjouterClient(Client client) {
            // Add a new client to the list of clients
            clients.Add(client);

            // Add the client to the database
            using (var context = new AppDbContext())
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }
        }



        public void SupprimerClient(int numClient)
        {
            comptes.RemoveAll(c => c.ClientId == numClient);
            // Remove all accounts associated with the client
          
            // Then remove the client 
            clients.RemoveAll(c => c.NumClient == numClient);

            // Remove the client from the database
            using (var context = new AppDbContext()) {

                // Remove the client from the database
                // Find the client in the database using the provided ID
                // If found, remove it from the database
                // Save changes to the database
                //we can also use Find to find the client 
                var clientToRemove = context.Clients.Where(c => c.NumClient == numClient);

                if (clientToRemove.Any()) {

                    // Remove all accounts associated with the client
                    var compteToRemove =  context.Clomptes.Where(c => c.ClientId == numClient);
                    foreach(Compte comptes in compteToRemove) {
                        context.Clomptes.Remove(comptes);
                    }

                    context.Clients.Remove(clientToRemove.First());
                    context.SaveChanges();

                }


            }

        }

        public Client SearchClient(int numClient) {
            // Search for a client by their ID
            // Return the first client that matches the ID
            // If no client is found, return null

            var client = clients.FirstOrDefault(c => c.NumClient == numClient);

            if(client == null)
            {
                // If the client is not found in the list, search in the database
                using (var context = new AppDbContext())
                {
                    client = context.Clients.FirstOrDefault(c => c.NumClient == numClient);
                }
            }

            return client;


        }

      
        public List<Client> SeachByName( String name)
        {
            // Search for a client by their name
            // Return the first client that matches the name
            // If no client is found, return null
            var client = clients.Where(c => c.Nom.StartsWith(name)).ToList();
            if(client == null)
            {
               using (var context = new AppDbContext())
                {
                    client  = context.Clients.Where(c=> c.Nom.StartsWith(name)).ToList();
                }
            } return client;
        }

        public void AddCompte( Compte compte)
        {
            comptes.Add(compte);
            // Add the account to the database
            using (var context = new AppDbContext())
            {   
                context.Clomptes.Add(compte);
                context.SaveChanges();
            } 
        }

        public void DeleteCompte(int numCompte)
        {
            // Remove the account from the list of accounts
            comptes.RemoveAll(c => c.NumCompte == numCompte);

            // Remove the account from the database

            using( var  context = new AppDbContext())
            {
                context.Clomptes.Where(c => c.NumCompte == numCompte).
                    ToList().ForEach(c => context.Clomptes.Remove(c));
            }
        }

        public Compte? RechercherCompte(int NumCompte)
        {
            return comptes.FirstOrDefault(c => c.NumCompte == NumCompte);
        }

        public List<Compte> RechercherComptesParClient(int NumClient) => comptes.Where(c => c.ClientId == NumClient).ToList();

        public bool Virement(int SourceId, int DestinationId, decimal montant)
        {
            var src = RechercherCompte(SourceId);
            var dest = RechercherCompte(DestinationId);
            if (src != null && dest != null && src.Debit(montant))
            {
                dest.Credit(montant);
                return true;
            }
            else
            {
                return false;
            }

        }



    }
}
