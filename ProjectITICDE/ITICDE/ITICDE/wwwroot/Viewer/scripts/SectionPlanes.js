//------------------------------------------------------------------------------------------------------------------
// Import the modules we need for this example
//------------------------------------------------------------------------------------------------------------------

import { SectionPlanesPlugin, math } from "../dist/xeokit-sdk.es.js";

//------------------------------------------------------------------------------------------------------------------
// Add a SectionPlanesPlugin - we'll use this to create cross-section planes
//------------------------------------------------------------------------------------------------------------------

const sectionPlanes = new SectionPlanesPlugin(viewer, {
  overviewCanvasId: "mySectionPlanesOverviewCanvas",
  overviewVisible: true,
});
var sectelemnt = document.getElementById("sectionbtn");
//------------------------------------------------------------------------------------------------------------------
// Use the AnnotationsPlugin to create an annotation wherever we click on an object
//------------------------------------------------------------------------------------------------------------------

var i = 1;

viewer.scene.input.on("mouseclicked", (coords) => {
  if (sectelemnt.classList.contains("disabled")) {
    return;
  }
  var pickResult = viewer.scene.pick({
    canvasPos: coords,
    pickSurface: true, // <<------ This causes picking to find the intersection point on the entity
  });

  if (pickResult && pickResult.worldNormal) {
    // Disallow SectionPlanes on point clouds, because points don't have normals

    const sectionPlane = sectionPlanes.createSectionPlane({
      id: i,
      pos: pickResult.worldPos,
      dir: math.mulVec3Scalar(pickResult.worldNormal, -1),
    });

    sectionPlanes.showControl(sectionPlane.id);

    i++;
  }
});

window.resetPlanes = function () {
  if (i > 1) {
    sectionPlanes.destroySectionPlane(i - 1);

    i--;
  }
};
window.viewer = viewer;
