# azure-resume
My own Azure resume following A Cloud Guru Projects video in 2021 https://www.youtube.com/watch?v=ieYrBWmkfno&list=PLI1_CQcV71Rn-Om5fPU47KExd7ZQjvpl9 (With adaptation to 2023 solutions)

- Project start date: 11 April 2023
- Project end date: 19 April 2023

Why I decided to take this challenge
After getting some CompTIA certifications and finishing LinkedIn Learning courses on CISSP and CISA, I decided to read through the materials of learning paths on Microsoft Learn but I quickly got burned out because I was just reading but not internalizing the knowledge to boost my technical skills meaningfully. I decided to switch from certification-based learning to project-based learning. I know Gwyn as a YouTuber who promotes her LearnToCloud platform, so I think following her tutorial would be a great start for my entry to cloud engineering knowledge, and adding the project to my tech portfolio would improve my chance to progress in the tech industry.

Previous knowledge applied
- Frontend and backend web development involving SQL learned from Coursera Specialization courses by the Unversity of Michigan

First-times
- Setting up SSH connection and cloning with Github, and Github Desktop
- Creating an Azure account with free credits
- Creating an Azure Cosmos DB for NoSQL database, Azure Cloud Shell with a Azure file storage, bill alerts
- Locating Azure resources such as Data Explorer
- Using new development tools and VS Code extensions such as .NET SDK 3.1, Azure Functions, Azure Functions Core Tools, Node.js
- Using tools such as Chocolatey for Windows and Hebrew for MacOS
- Prompting ChatGPT-3.5 and 4 to output coding ideas for GetResumeCounter.cs and main.js.
- Deploying the static website to Azure using Blob Storage. Adding HTTPS support and custom domain support.

Modifications of the frontend template for the website
- Add more nav links and troubleshoot CSS issues related to changing colors on scroll
- Fixing some CSS padding parameters for aesthetics
- Changing the Fa fa icons
- Cater to accessibility (alt text to pictures)

Major hiccups and solutions
- I was trying to finish this project using the NET SDK 3.1 version, following what Gwyn would do in her tutorial on YouTube. The reason why was probably that I installed the SDK without admin rights and that  Visual Studio Code 2022 is updated that it could not read SDK files properly. So, after hours of unsuccessful troubleshooting, I decided to use the latest versions of everything and adapt to them.
- On my personal Mac, I downloaded .NET SDK 7.0 (Arm64) so the latest Azure Functions Core Tools could support it. And when creating the azure function, I selected .NET SDK 7.0 and continue with func host start, and the Visitor Counter worked fine, with quite a few modifications to read CosmosDB and StringContent attributes properly. Troubleshooting took a lot of time to remove conflicting libraries. And a lot of testing and validation. But finally it worked after two full days of work.
- I realized the JsonProperty names are case-sensitive and prevented me to connect to Cosmos DB at one point. And I made a typo by typing "Hosts" instead of "Host" for CORS settings which prevented fetching API via Javascript. Took me a while to realize.
- The Github Actions workflow was not working with the template and the latest AZ CLI version. It turned out an "--overwrite true" flag is needed for the "az storage blob upload-batch" command.

Troubleshooting techniques
- Googling the questions I had/error codes. Most answers were on stackexchange and github discussion forums.
- YouTube tutorials also help when documentation is too overloaded. For example, for the function.json, I referenced https://www.youtube.com/watch?v=9DtLz1fcsBM .
- ChatGPT-3.5 was hesitant when trying to point out the errors.

Notes
- I found that Jeff Brown used another method to bind the Azure Cosmos DB. https://jeffbrown.tech/azure-cloud-resume-challenge-part-3/