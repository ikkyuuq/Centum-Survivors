### Generate SSH Key

1. Generate a New SSH Key:
   - `ssh-keygen -t rsa -b 4096 -C "your_email@example.com"`
   - It will be prompted to save the key (default is  ~/.ssh/id_rsa ) and to enter a passphrase.
2. Add SSH Key to the SSH-Agent:
   - `eval $(ssh-agent -s)`
   - `ssh-add ~/.ssh/id_rsa`
3. Copy the SSH Key:
   - `cat ~/.ssh/id_rsa.pub`
   - Copy the output, which is public key.

### Add SSH Key to Git Hosting Service

1. Add the SSH Key to GitHub (or GitLab, Bitbucket):
   - Navigate to Settings > SSH and GPG keys > New SSH key.
   - Paste the copied public key.

### Collaborating

1. Cloning the Repository:
   - `git clone git@github.com:ikkyuuq/Centum-Survivors.git`
   
2. Opening the Project in Unity:
   - open Unity Hub and add the cloned project directory to the list of projects.
  
### Git

1. Git Workflow:
   - **Pull** the latest changes from the remote repository **before starting any new work**:
     `git pull origin main`

   - Create a **new branch** for each feature or fix:
     `git checkout -b feature/your-feature-name`

   - Add and **commit** changes **in your branch**:
     `git add .`
     `git commit -m "Description of your changes"`
     
   - Push your branch to the remote repository:
     `git push origin feature/your-feature-name`
     
   - Create a **pull request from your branch to the main branch** on your Git
     
2. Merging Changes:
   - **Review** and **merge** changes **through pull requests.**
   - Ensure to **delete** the feature branch **after merging.**
