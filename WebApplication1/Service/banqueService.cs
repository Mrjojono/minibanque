using minibanque.Models;

namespace minibanque.Service
{
    public class banqueService
    {
        private List<Client> clients = new List<Client>();
        private List<Compte> comptes = new List<Compte>();
        public void AjouterClient(Client client) => clients.Add(client);
     

        public void SupprimerClient(int numClient)
        {
            comptes.RemoveAll(c => c.ClientId == numClient);
            // Remove all accounts associated with the client
            // Then remove the client 
            clients.RemoveAll(c => c.NumClient == numClient);

        }

        public Client SearchClient(int numClient) {
            // Search for a client by their ID
            // Return the first client that matches the ID
            // If no client is found, return null
            return clients.FirstOrDefault(c => c.NumClient == numClient);

        }

      
        public List<Client> SeachByName( String name)
        {
            // Search for a client by their name
            // Return the first client that matches the name
            // If no client is found, return null
            return  clients.Where(c => c.Nom.StartsWith(name)).ToList();
        }

        public void AddCompte( Compte compte)
        {
            comptes.Add(compte);
        }

        public void DeleteCompte(int numCompte)
        {
            // Remove the account from the list of accounts
            comptes.RemoveAll(c => c.NumCompte == numCompte);
        }


    }
}
