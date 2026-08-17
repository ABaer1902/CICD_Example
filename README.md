# Avalonia CI/CD Demo
This repository serves as a proof of concept for Adam Baer's CI/CD model tailored for the Avalonia stack.
The model utilizes:
- Github Actions
- Docker
- .Net (Avalonia)
- Bash
- Azure VMs
### Project Overview
![Demo Implementation Overview](<img width="1695" height="1003" alt="CI_CD Diagram - Page 1" src="https://github.com/user-attachments/assets/121c8f4b-69fc-4440-9f93-a4e1bf625ef2" />
)
### Growth Overview
![Full CI/CD Overview](<img width="4575" height="2119" alt="CI_CD Diagram" src="https://github.com/user-attachments/assets/7ebb4104-6995-4e50-8cd5-cc1f5f8aad78" />
)
The Full CI/CD pipeline design is meant to establish 4 main points of validation.
- Source- How engineers are allowed to push and pull code.
- Build- The setup and install of the environment and dependencies for the app
- Test- Any validation that must occur at runtime (ex. Leak tests, UI validation... etc)
- Release- The process at which delivering the product to customers is automated or protected
### Application Overview
This application labeled *AvaloniaApplication1* is the application that is tested throughout this CI/CD example. It is an extremely basic example of an Avalonia app with 3 features.
- A button that adds an entry to a local database using SQLite
- A button that queries the count of the database using SQLite
- A textbox that shows responses for the 2 buttons listed above

## Key Focuses
### Integration Tests
The demo contains one Github Action named `Ubuntu_Test`.
This action is triggered by any push to the main branch, as well as a manual trigger on the repository's action page. [This Repos Actions](https://github.com/ABaer1902/CICD_Example/actions).
### Build/Image Verification and Storage
Throughout the demo, the app attached to the repository is built, tested and validated using docker images. These images, both failed and passed, are stored using the actions. If the test failed, the image is kept as a downloadable tar file that can be downloaded and reproduced.
To do this:
1. Access the failed test on the [Actions tab of the repository](https://github.com/ABaer1902/CICD_Example/actions)
2. Scroll to where you can see "Artifacts"
3. Download the artifact
4. Extract the file so the tar file is visible
5. run `docker load -i avalonia-app-test.tar` to download the image
6. run `docker images`. You should see avalonia-app-test.tar listed as a possible image
7. run `docker run avalonia-app-test.tar` to run the container
The replicated container will be the **exact environment** which caused the crash on the remote machine. All artifacts made have a current lifespan of 7 days before they are removed.
### Basic Unit Testing
Before running the integration tests, *Ubuntu_Test* will compile the code, run a basic coverage test run an established set of unit tests. The tests provided are very minimal as they are a stand-in for more complicated testing in the future.


## More Information
For more information about Adam Baer (this projects developer).
- Please reach out at ABaer1902@gmail.com
- Visit [Github](https://github.com/ABaer1902)
- Visit www.linkedin.com/in/adam-baer-3a4bb4279

## License & Copyright

Copyright (c) 2026 Adam Baer. All rights reserved. 

This project is protected by copyright. Unauthorized copying, modification, or distribution is prohibited.
