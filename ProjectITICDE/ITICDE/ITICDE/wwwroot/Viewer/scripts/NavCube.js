import { NavCubePlugin } from "../dist/xeokit-sdk.es.js";

new NavCubePlugin(viewer, {
  canvasId: "myNavCubeCanvas",
  color: "lightblue",
  visible: true, // Initially visible (default)
  cameraFly: true, // Fly camera to each selected axis/diagonal
  cameraFitFOV: 45, // How much field-of-view the scene takes once camera has fitted it to view
  cameraFlyDuration: 0.5, // How long (in seconds) camera takes to fly to each new axis/diagonal
});


