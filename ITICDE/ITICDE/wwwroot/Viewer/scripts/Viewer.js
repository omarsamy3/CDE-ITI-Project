//------------------------------------------------------------------------------------------------------------------
// Import the modules we need for this example
//------------------------------------------------------------------------------------------------------------------

import { Viewer } from "../dist/xeokit-sdk.es.js";

//------------------------------------------------------------------------------------------------------------------
// Create a Viewer, arrange the camera
//------------------------------------------------------------------------------------------------------------------
const viewer = new Viewer({
  canvasId: "myCanvas",
  transparent: false,
  backgroundColor: [0.92941176471, 0.92941176471, 0.92941176471],
});

window.SetCamera = function () {
  let a = viewer.camera.canvasPos;
  document.getElementById("toggle3d").classList.toggle("active");
  if (viewer.camera.projection == "perspective") {
    viewer.cameraFlight.flyTo({
      projection: "ortho",

      duration: 0.5,
    });
  } else {
    viewer.cameraFlight.flyTo({ projection: "perspective", duration: 0.5 });
  }
};
window.ResetViewer = function () {
  viewer.cameraFlight.flyTo({
    projection: "perspective",
    eye: [-10, 5, 15],
    look: [10, 5, 0],
    up: [0, 1, 0],
    duration: 1, // Default, seconds}
  });
};

viewer.camera.eye = [-10, 5, 15]; //[-2.56, 8.38, 8.27];
viewer.camera.look = [10, 5, 0];
viewer.camera.up = [0, 1, 0];

viewer.camera.projection = "perspective";
viewer.scene.xrayMaterial.fill = true;
viewer.scene.xrayMaterial.fillAlpha = 0.1;
viewer.scene.xrayMaterial.fillColor = [0, 0, 0];
viewer.scene.xrayMaterial.edgeAlpha = 0.3;
viewer.scene.xrayMaterial.edgeColor = [0, 0, 0];

viewer.scene.highlightMaterial.fill = true;
viewer.scene.highlightMaterial.edges = true;
viewer.scene.highlightMaterial.fillAlpha = 0.1;
viewer.scene.highlightMaterial.edgeAlpha = 0.1;
viewer.scene.highlightMaterial.edgeColor = [1, 1, 0];

viewer.scene.selectedMaterial.fill = true;
viewer.scene.selectedMaterial.edges = true;
viewer.scene.selectedMaterial.fillAlpha = 0.5;
viewer.scene.selectedMaterial.edgeAlpha = 0.6;
viewer.scene.selectedMaterial.edgeColor = [0, 1, 1];

viewer.cameraControl.followPointer = true;

//----------------------------------------------------------------------------------------------------------------------
// Create a tree view
//----------------------------------------------------------------------------------------------------------------------
//code was here//
//------------------------------------------------------------------------------------------------------------------
// Create two ContextMenus - one for right-click on empty space, the other for right-click on an Entity
//------------------------------------------------------------------------------------------------------------------
//put code here//

//------------------------------------------------------------------------------------------------------------------
// Load IFC Models
//------------------------------------------------------------------------------------------------------------------
// code was here

//------------------------------------------------------------------------------------------------------------------
// Mouse over entities to highlight them
//------------------------------------------------------------------------------------------------------------------
const buttonElement = document.getElementById("Query");

buttonElement.onclick = function () {
  buttonElement.classList.toggle("active");
  if(buttonElement.classList.contains("active")){
    
  }
 
 else{
  //document.getElementById("details").remove();
  detailselem.remove();
  detailselem.innerHTML="";
}
  
  if(lastEntity!=null)
  {lastEntity.highlighted = false;}
  
};
window.lastEntity = null;

viewer.cameraControl.on("hover", function (pickResult) {
  if (buttonElement.classList.contains("active")) {
    if (pickResult) {
      if (!lastEntity || pickResult.entity.id !== lastEntity.id) {
        if (lastEntity) {
          lastEntity.highlighted = false;
        }

        lastEntity = pickResult.entity;
        pickResult.entity.highlighted = true;
      }
    } else {
      if (lastEntity) {
        lastEntity.highlighted = false;
        lastEntity = null;
      }
    }
  }
});
const detailselem = document.createElement("div");
detailselem.id="details";
detailselem.classList.add("details");

viewer.cameraControl.on("picked", function (pickResult) {
  if (buttonElement.classList.contains("active")) {
  let id = pickResult.entity.id;
  let obj = viewer.metaScene.metaObjects[id];
  // {
  //   id: obj.id,
  //   Name: obj.name,
  //   Type: obj.type,
  // };
  document.getElementById("myToolbar").after(detailselem);
  detailselem.innerHTML  = "id: " + obj.id +"<br>"+"Name: "+ obj.name+"<br>"+"Type: "+ obj.type
   //console.log(JSON.static(obj)) ;
  console.log(obj);
}
});

window.viewer = viewer;
