var Files = [{
        folderid: null,
        Name: "file1",
        Path: "../../here"
    },

    {
        folderid: null,
        Name: "file2",
        Path: "../../here"
    },
    {
        folderid: 2,
        Name: "file3",
        Path: "../../here"
    },
    {
        folderid: null,
        Name: "file4",
        Path: "../../here"
    },
    {
        folderid: 3,
        Name: "file5",
        Path: "../../here"
    },
    {
        folderid: 1,
        Name: "file6",
        Path: "../../here"
    }


]

var Folders = [{
        id: 1,
        parentid: null,
        Name: "folder1",
        Path: "../../here1"
    },
    {
        id: 2,
        parentid: null,
        Name: "folder2",
        Path: "../../here2"
    },
    {
        id: 3,
        parentid: 1,
        Name: "folder3",
        Path: "../../here3"
    },
    {
        id: 4,
        parentid: 2,
        Name: "folder4",
        Path: "../../here3"
    },
    {
        id: 5,
        parentid: 4,
        Name: "folder5",
        Path: "../../here3"
    }


]


var mainelement = document.getElementById("treeViewContainer");

var listdiv = document.createElement("div");
listdiv.id = "sidelist";
var listul = document.createElement("ul");
var projectrootli = document.createElement("li");
projectrootli.id=0;
var projectrootul = document.createElement("ul");




function AddExplorerList() {
    document.getElementById("explorerside").classList.add("activeside");
    document.getElementById("projectsside").classList.remove("activeside");
    mainelement.innerHTML="";
    mainelement.append(listdiv);
    listdiv.append(listul);
    projectrootli.innerHTML = ` <span class="folderfold" onclick="createFolderHTML(0)" id="spanfold0">+</span><span>Project</span>`;
    listul.appendChild(projectrootli);
    projectrootul.innerHTML="";
    projectrootli.appendChild(projectrootul);
    //createFolderHTML(projectrootul);
}

function getfolder(id)
{
    for (let index = 0; index < Folders.length; index++) {
        if(Folders[index].id==id)
        {
            return Folders[index];
        }
        
    }
}





//main function
function createFolderHTML(id) {

let span =document.getElementById("spanfold"+id)
if(span.innerHTML=="+")
{
    let folderul=null;
    let folder=null;
   
   if(id==0)
   {folderul=projectrootul}
   else{
       folderul=document.createElement("ul");
       document.getElementById(id).appendChild(folderul);
       folder=getfolder(id);
   }
   
       loadinnerfolders(folder, folderul);
       span.innerHTML="-"
}
else{
    span.innerHTML="+"
let lielem = document.getElementById(id);
if(id==0)
{
    lielem.lastChild.innerHTML=" ";
}
else{
    lielem.removeChild(lielem.lastChild);

}

}

}

function CreatePlusSpan(folderli) {
    let spanplus = document.createElement("span");
    spanplus.innerHTML = "+"
    spanplus.classList.add("folderfold");
    spanplus.setAttribute('onclick', `createFolderHTML(${folderli.id})`);
spanplus.id="spanfold"+folderli.id;
    folderli.appendChild(spanplus);
}


function CreateFolderSpan(folder, folderli) {
    let folderspan = document.createElement("span");

    folderspan.innerHTML = folder.Name;
    folderli.appendChild(folderspan);

}


function loadinnerfolders(folder, folderul) {
    for (let i = 0; i < Folders.length; i++) {
      
        
        if (folder != null) {
           
            if (Folders[i].parentid == folder.id) {
                var folderli = document.createElement("li");
                folderli.id = Folders[i].id;
                folderul.appendChild(folderli);
                CreatePlusSpan(folderli);
                CreateFolderSpan(Folders[i], folderli);
            }
        } else {
            var folderli = document.createElement("li");
            folderli.id = Folders[i].id;
            if (Folders[i].parentid == null) {
                var folderli = document.createElement("li");
                folderli.id = Folders[i].id;
                folderul.appendChild(folderli);
                CreatePlusSpan(folderli);
                CreateFolderSpan(Folders[i], folderli);
            }
        }

    }

    loadfiles(folder, folderul)

}

function loadfiles(folder, folderul) {
    if (folder == null) {
        folderul = projectrootul;
    }
    if (folder != null) {
        let fid = folder.id;
        Files.forEach(function (file) {
            if (file.folderid == fid) {
                fnameli = document.createElement("li")

                var chckbox = document.createElement("INPUT");
                chckbox.setAttribute("type", "checkbox");
                chckbox.setAttribute("onclick", `console.log('${file.Path}')`);
                chckbox.classList.add("ExplChckbox")
                fnameli.appendChild(chckbox);
                fnameli.append(file.Name);
                folderul.appendChild(fnameli);
            }

        })
    } else {
        Files.forEach(function (file) {
            if (file.folderid == null) {
                fnameli = document.createElement("li")

                var chckbox = document.createElement("INPUT");
                chckbox.setAttribute("type", "checkbox");
                chckbox.setAttribute("onclick", `console.log('${file.Path}')`);
                chckbox.classList.add("ExplChckbox")
                fnameli.appendChild(chckbox);
                fnameli.append(file.Name);
                folderul.appendChild(fnameli);
            }

        })
    }

}