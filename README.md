

<h1 align="center"> Bay Bridge</h1>

<p align="center">
   <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/Logo.ico" alt="Build Status" width="300">
</p>

## Description:
 
A web-based application to prove the concept of The Common Data Environment (CDE) in The BIM Process, to gather all the project parties in one place to communicate easily with each other and follow up on the project status in real-time and navigate the project files and models, also you can assign tasks for users or teams to do in a specific time.

## main features

- Nice looking User Interface

- server side validation

- Communicate with `All Project Parties`

- File Explorer.

- The ability to `Assign Tasks` to other Project users or teams.

- The ability to `Upload different kinds of files` 

- PDF, Img, Video and IFC Viewers.

- The ability to make `Teams with a leader to lead them`

## Designs

### Database ERD
<p align="center">
       <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/Database.png" alt="Build Status">
</p>

#### Client Application

The client application consists mainly of 3 packages

- `controllers`: This pacakage is Responsible for dealing with the app views

- `models`: This package is for storing the data of the entities that send from the server
    - `User`
    - `Team`
    - `Project`
    - `File`
    - `Folder`
    - `Task`
    - `View`

- `Views`:` This package is the views of the models and their CRUD operations you want to do.
    
#### Server Application

The big boss in this  app The server is the responsable for every thing
- validating User data
- connecting with the database 
- stablish the conection between Users
- receiving the message from User and send it to the other one etc...


## The Web Application

>When you open our website you will find the welcome page and our website features.
   
<p align="center">
    <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/Welcome.png" alt="Build Status">
</p>


### Login & Register process

#### indexView
this is the `login` view if you want to access the your projects in the CDE.
<p align="center">
       <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/Login.png" alt="Build Status">
</p>


#### register
>this is the `Register` view if you want to enter the CDE for the first time to be added in your projects.

<p align="center">
    <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/Register.png" alt="Build Status">
</p>


>after the User login successfully he will get the welcome screen and informed <br>
>with the information with the page of his work-on projects.
<p align="center">
       <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/Projects.png" alt="Build Status">
</p>

## The Project user interface.
<br>
>After you login, you can access all your projects. <br>
>But you can edit or delete only the projects you have created.

<p align="center">
       <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/Access%20Projects.png" alt="Build Status">
</p>
>Create Project.
<p align="center">
       <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/CreateProject.png" alt="Build Status">
</p>

>When you Enter any of your projects, your will be redirected to the project file explorer. <br>
>You can make new folders or upload different kinds of files like PDF, IFC, Xlsx, rfa, jpg, png, mp4...
<p align="center">
       <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/File%20Explorer.png" alt="Build Status">
</p>

>PDF Viewer <br>
>If you Entered any PDF, Image or Video file it will open and you can edit the PDF file and save it as a new one.
<p align="center">
       <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/PDF%20Viewer.png" alt="Build Status">
</p>

>IFC Viewer. <br>
>You can view any IFC file as it represents the project model. <br>
>You can navigate the model and show each element and hide what you want.
<p align="center">
       <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/IFC%20Viewer.png" alt="Build Status">
</p>

>Teams <br>
>You can make teams with its leader and add users in it to have task to do.
<p align="center">
       <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/Teams.png" alt="Build Status">
</p>
>Team Users
<p align="center">
       <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/Team%20Users.png" alt="Build Status">
</p>
>Tasks <br>
>Having the ability to assign tasks to users or teams with some instructures or a specific view.
<p align="center">
       <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/Tasks.png" alt="Build Status">
</p>
>Create Tasks
<p align="center">
       <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/CreateTask.png" alt="Build Status">
</p>
>Views
>Here where you can save views from the IFC viewer to assign them as tasks.
<p align="center">
       <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/Views.png" alt="Build Status">
</p>

>Save View
<p align="center">
       <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/Save%20View.png" alt="Build Status">
</p>

>New Task Alert <br>
>If you have a task, you will find this alert when you login the project.
<p align="center">
       <img src="https://github.com/omarsamy3/CDEITIProject/blob/main/ITICDE/ITICDE/wwwroot/dist/img/GitHubProjectPhotos/New%20Task%20Alert.png" alt="Build Status">
</p>


<table>
  <tr>
    <td>
      <img src="https://avatars.githubusercontent.com/u/76973221?v=4"> </img>
    </td>
    <td>
      <img src="https://avatars.githubusercontent.com/u/106613861?v=4g"></img>
    </td>
  </tr>
  <tr>
    <td>
      <a href="https://github.com/omarsamy3"> Omar Samy </a>
    </td>
    <td>
      <a href="https://github.com/MohamedAyman21"> Mohammed Ayman </a>
    </td>
  </tr>
   <tr>
    <td>
      <img src="https://avatars.githubusercontent.com/u/105270767?v=4"></img>
    </td>
    <td>
      <img src="https://avatars.githubusercontent.com/u/106573824?v=4"></img>
    </td>
  </tr>
 <tr>
    <td>
      <a href="https://github.com/AboubakrNasef"> Aboubakr Naser </a>
    </td>
     <td>
      <a href="https://github.com/MariamRohayiem"> Mariam Rashad </a>
    </td>
  </tr>
</table>
