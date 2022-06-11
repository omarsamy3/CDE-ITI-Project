import { ContextMenu, TreeViewPlugin } from "../dist/xeokit-sdk.es.js";

//----------------------------------------------------------------------------------------------------------------------
// Create a tree view
//----------------------------------------------------------------------------------------------------------------------
var treeView = new TreeViewPlugin(viewer, {
  containerElement: document.getElementById("treeViewContainer"),
  autoExpandDepth: 1,
  hierarchy: "containment",
});
window.ChangeTree = function (hierarchy) {
  treeView.hierarchy = hierarchy;
};

const treeViewContextMenu = new ContextMenu({
  items: [
    [
      {
        title: "View Fit",
        doAction: function (context) {
          const scene = context.viewer.scene;
          const objectIds = [];
          context.treeViewPlugin.withNodeTree(
            context.treeViewNode,
            (treeViewNode) => {
              if (treeViewNode.objectId) {
                objectIds.push(treeViewNode.objectId);
              }
            }
          );
          scene.setObjectsVisible(objectIds, true);
          scene.setObjectsHighlighted(objectIds, true);
          context.viewer.cameraFlight.flyTo(
            {
              projection: "perspective",
              aabb: scene.getAABB(objectIds),
              duration: 0.5,
            },
            () => {
              setTimeout(function () {
                scene.setObjectsHighlighted(scene.highlightedObjectIds, false);
              }, 500);
            }
          );
        },
      },
      {
        title: "View Fit All",
        doAction: function (context) {
          const scene = context.viewer.scene;
          context.viewer.cameraFlight.flyTo({
            projection: "perspective",
            aabb: scene.getAABB({}),
            duration: 0.5,
          });
        },
      },
    ],
    [
      {
        title: "Hide",
        doAction: function (context) {
          context.treeViewPlugin.withNodeTree(
            context.treeViewNode,
            (treeViewNode) => {
              if (treeViewNode.objectId) {
                const entity =
                  context.viewer.scene.objects[treeViewNode.objectId];
                if (entity) {
                  entity.visible = false;
                }
              }
            }
          );
        },
      },
      {
        title: "Hide Others",
        doAction: function (context) {
          const scene = context.viewer.scene;
          scene.setObjectsVisible(scene.visibleObjectIds, false);
          scene.setObjectsXRayed(scene.xrayedObjectIds, false);
          scene.setObjectsSelected(scene.selectedObjectIds, false);
          scene.setObjectsHighlighted(scene.highlightedObjectIds, false);
          context.treeViewPlugin.withNodeTree(
            context.treeViewNode,
            (treeViewNode) => {
              if (treeViewNode.objectId) {
                const entity = scene.objects[treeViewNode.objectId];
                if (entity) {
                  entity.visible = true;
                }
              }
            }
          );
        },
      },
      {
        title: "Hide All",
        getEnabled: function (context) {
          return context.viewer.scene.visibleObjectIds.length > 0;
        },
        doAction: function (context) {
          context.viewer.scene.setObjectsVisible(
            context.viewer.scene.visibleObjectIds,
            false
          );
        },
      },
    ],
    [
      {
        title: "Show",
        doAction: function (context) {
          context.treeViewPlugin.withNodeTree(
            context.treeViewNode,
            (treeViewNode) => {
              if (treeViewNode.objectId) {
                const entity =
                  context.viewer.scene.objects[treeViewNode.objectId];
                if (entity) {
                  entity.visible = true;
                  entity.xrayed = false;
                  entity.selected = false;
                }
              }
            }
          );
        },
      },
      {
        title: "Show Others",
        doAction: function (context) {
          const scene = context.viewer.scene;
          scene.setObjectsVisible(scene.objectIds, true);
          scene.setObjectsXRayed(scene.xrayedObjectIds, false);
          scene.setObjectsSelected(scene.selectedObjectIds, false);
          context.treeViewPlugin.withNodeTree(
            context.treeViewNode,
            (treeViewNode) => {
              if (treeViewNode.objectId) {
                const entity = scene.objects[treeViewNode.objectId];
                if (entity) {
                  entity.visible = false;
                }
              }
            }
          );
        },
      },
      {
        title: "Show All",
        getEnabled: function (context) {
          const scene = context.viewer.scene;
          return scene.numVisibleObjects < scene.numObjects;
        },
        doAction: function (context) {
          const scene = context.viewer.scene;
          scene.setObjectsVisible(scene.objectIds, true);
          scene.setObjectsXRayed(scene.xrayedObjectIds, false);
          scene.setObjectsSelected(scene.selectedObjectIds, false);
        },
      },
    ],
    [
      {
        title: "X-Ray",
        doAction: function (context) {
          context.treeViewPlugin.withNodeTree(
            context.treeViewNode,
            (treeViewNode) => {
              if (treeViewNode.objectId) {
                const entity =
                  context.viewer.scene.objects[treeViewNode.objectId];
                if (entity) {
                  entity.xrayed = true;
                  entity.visible = true;
                }
              }
            }
          );
        },
      },
      {
        title: "Undo X-Ray",
        doAction: function (context) {
          context.treeViewPlugin.withNodeTree(
            context.treeViewNode,
            (treeViewNode) => {
              if (treeViewNode.objectId) {
                const entity =
                  context.viewer.scene.objects[treeViewNode.objectId];
                if (entity) {
                  entity.xrayed = false;
                }
              }
            }
          );
        },
      },
      {
        title: "X-Ray Others",
        doAction: function (context) {
          const scene = context.viewer.scene;
          scene.setObjectsVisible(scene.objectIds, true);
          scene.setObjectsXRayed(scene.objectIds, true);
          scene.setObjectsSelected(scene.selectedObjectIds, false);
          scene.setObjectsHighlighted(scene.highlightedObjectIds, false);
          context.treeViewPlugin.withNodeTree(
            context.treeViewNode,
            (treeViewNode) => {
              if (treeViewNode.objectId) {
                const entity = scene.objects[treeViewNode.objectId];
                if (entity) {
                  entity.xrayed = false;
                }
              }
            }
          );
        },
      },
      {
        title: "Reset X-Ray",
        getEnabled: function (context) {
          return context.viewer.scene.numXRayedObjects > 0;
        },
        doAction: function (context) {
          context.viewer.scene.setObjectsXRayed(
            context.viewer.scene.xrayedObjectIds,
            false
          );
        },
      },
    ],
    [
      {
        title: "Select",
        doAction: function (context) {
          context.treeViewPlugin.withNodeTree(
            context.treeViewNode,
            (treeViewNode) => {
              if (treeViewNode.objectId) {
                const entity =
                  context.viewer.scene.objects[treeViewNode.objectId];
                if (entity) {
                  entity.selected = true;
                  entity.visible = true;
                }
              }
            }
          );
        },
      },
      {
        title: "Deselect",
        doAction: function (context) {
          context.treeViewPlugin.withNodeTree(
            context.treeViewNode,
            (treeViewNode) => {
              if (treeViewNode.objectId) {
                const entity =
                  context.viewer.scene.objects[treeViewNode.objectId];
                if (entity) {
                  entity.selected = false;
                }
              }
            }
          );
        },
      },
      {
        title: "Clear Selection",
        getEnabled: function (context) {
          return context.viewer.scene.numSelectedObjects > 0;
        },
        doAction: function (context) {
          context.viewer.scene.setObjectsSelected(
            context.viewer.scene.selectedObjectIds,
            false
          );
        },
      },
    ],
  ],
});

// Right-clicking on a tree node shows the context menu for that node

treeView.on("contextmenu", (e) => {
  treeViewContextMenu.context = {
    // Must set context before opening menu
    viewer: e.viewer,
    treeViewPlugin: e.treeViewPlugin,
    treeViewNode: e.treeViewNode,
    entity: e.viewer.scene.objects[e.treeViewNode.objectId], // Only defined if tree node is a leaf node
  };

  treeViewContextMenu.show(e.event.pageX, e.event.pageY);
});

// Left-clicking on a tree node isolates that object in the 3D view

treeView.on("nodeTitleClicked", (e) => {
  const scene = viewer.scene;
  const objectIds = [];
  e.treeViewPlugin.withNodeTree(e.treeViewNode, (treeViewNode) => {
    if (treeViewNode.objectId) {
      objectIds.push(treeViewNode.objectId);
    }
  });
  e.treeViewPlugin.unShowNode();
  scene.setObjectsXRayed(scene.objectIds, true);
  scene.setObjectsVisible(scene.objectIds, true);
  scene.setObjectsXRayed(objectIds, false);
  viewer.cameraFlight.flyTo(
    {
      aabb: scene.getAABB(objectIds),
      duration: 0.5,
    },
    () => {
      setTimeout(function () {
        scene.setObjectsVisible(scene.xrayedObjectIds, false);
        scene.setObjectsXRayed(scene.xrayedObjectIds, false);
      }, 500);
    }
  );
});
//------------------------------------------------------------------------------------------------------------------
// Create two ContextMenus - one for right-click on empty space, the other for right-click on an Entity
//------------------------------------------------------------------------------------------------------------------

const canvasContextMenu = new ContextMenu({
  enabled: true,
  context: {
    viewer: viewer,
  },
  items: [
    [
      {
        title: "Hide All",
        getEnabled: function (context) {
          return context.viewer.scene.numVisibleObjects > 0;
        },
        doAction: function (context) {
          context.viewer.scene.setObjectsVisible(
            context.viewer.scene.visibleObjectIds,
            false
          );
        },
      },
      {
        title: "Show All",
        getEnabled: function (context) {
          const scene = context.viewer.scene;
          return scene.numVisibleObjects < scene.numObjects;
        },
        doAction: function (context) {
          const scene = context.viewer.scene;
          scene.setObjectsVisible(scene.objectIds, true);
          scene.setObjectsXRayed(scene.xrayedObjectIds, false);
          scene.setObjectsSelected(scene.selectedObjectIds, false);
        },
      },
    ],
    [
      {
        title: "View Fit All",
        doAction: function (context) {
          context.viewer.cameraFlight.flyTo({
            aabb: context.viewer.scene.getAABB(),
          });
        },
      },
    ],
  ],
});

const objectContextMenu = new ContextMenu({
  items: [
    [
      {
        title: "View Fit",
        doAction: function (context) {
          const viewer = context.viewer;
          const scene = viewer.scene;
          const entity = context.entity;
          viewer.cameraFlight.flyTo(
            {
              aabb: entity.aabb,
              duration: 0.5,
            },
            () => {
              setTimeout(function () {
                scene.setObjectsHighlighted(scene.highlightedObjectIds, false);
              }, 500);
            }
          );
        },
      },
      {
        title: "View Fit All",
        doAction: function (context) {
          const scene = context.viewer.scene;
          context.viewer.cameraFlight.flyTo({
            projection: "perspective",
            aabb: scene.getAABB(),
            duration: 0.5,
          });
        },
      },
      {
        title: "Show in Tree",
        doAction: function (context) {
          const objectId = context.entity.id;
          context.treeViewPlugin.showNode(objectId);
        },
      },
    ],
    [
      {
        title: "Hide",
        getEnabled: function (context) {
          return context.entity.visible;
        },
        doAction: function (context) {
          context.entity.visible = false;
        },
      },
      {
        title: "Hide Others",
        doAction: function (context) {
          const viewer = context.viewer;
          const scene = viewer.scene;
          const entity = context.entity;
          const metaObject = viewer.metaScene.metaObjects[entity.id];
          if (!metaObject) {
            return;
          }
          scene.setObjectsVisible(scene.visibleObjectIds, false);
          scene.setObjectsXRayed(scene.xrayedObjectIds, false);
          scene.setObjectsSelected(scene.selectedObjectIds, false);
          scene.setObjectsHighlighted(scene.highlightedObjectIds, false);
          metaObject.withMetaObjectsInSubtree((metaObject) => {
            const entity = scene.objects[metaObject.id];
            if (entity) {
              entity.visible = true;
            }
          });
        },
      },
      {
        title: "Hide All",
        getEnabled: function (context) {
          return context.viewer.scene.numVisibleObjects > 0;
        },
        doAction: function (context) {
          context.viewer.scene.setObjectsVisible(
            context.viewer.scene.visibleObjectIds,
            false
          );
        },
      },
      {
        title: "Show All",
        getEnabled: function (context) {
          const scene = context.viewer.scene;
          return scene.numVisibleObjects < scene.numObjects;
        },
        doAction: function (context) {
          const scene = context.viewer.scene;
          scene.setObjectsVisible(scene.objectIds, true);
        },
      },
    ],
    [
      {
        title: "X-Ray",
        getEnabled: function (context) {
          return !context.entity.xrayed;
        },
        doAction: function (context) {
          context.entity.xrayed = true;
        },
      },
      {
        title: "Undo X-Ray",
        getEnabled: function (context) {
          return context.entity.xrayed;
        },
        doAction: function (context) {
          context.entity.xrayed = false;
        },
      },
      {
        title: "X-Ray Others",
        doAction: function (context) {
          const viewer = context.viewer;
          const scene = viewer.scene;
          const entity = context.entity;
          const metaObject = viewer.metaScene.metaObjects[entity.id];
          if (!metaObject) {
            return;
          }
          scene.setObjectsVisible(scene.objectIds, true);
          scene.setObjectsXRayed(scene.objectIds, true);
          scene.setObjectsSelected(scene.selectedObjectIds, false);
          scene.setObjectsHighlighted(scene.highlightedObjectIds, false);
          metaObject.withMetaObjectsInSubtree((metaObject) => {
            const entity = scene.objects[metaObject.id];
            if (entity) {
              entity.xrayed = false;
            }
          });
        },
      },
      {
        title: "Reset X-Ray",
        getEnabled: function (context) {
          return context.viewer.scene.numXRayedObjects > 0;
        },
        doAction: function (context) {
          context.viewer.scene.setObjectsXRayed(
            context.viewer.scene.xrayedObjectIds,
            false
          );
        },
      },
    ],
    [
      {
        title: "Select",
        getEnabled: function (context) {
          return !context.entity.selected;
        },
        doAction: function (context) {
          context.entity.selected = true;
        },
      },
      {
        title: "Undo select",
        getEnabled: function (context) {
          return context.entity.selected;
        },
        doAction: function (context) {
          context.entity.selected = false;
        },
      },
      {
        title: "Clear Selection",
        getEnabled: function (context) {
          return context.viewer.scene.numSelectedObjects > 0;
        },
        doAction: function (context) {
          context.viewer.scene.setObjectsSelected(
            context.viewer.scene.selectedObjectIds,
            false
          );
        },
      },
    ],
  ],
  enabled: true,
});

viewer.cameraControl.on("rightClick", function (e) {
  var hit = viewer.scene.pick({
    canvasPos: e.canvasPos,
  });

  if (hit && hit.entity.isObject) {
    objectContextMenu.context = {
      // Must set context before showing menu
      viewer: viewer,
      treeViewPlugin: treeView,
      entity: hit.entity,
    };

    objectContextMenu.show(e.pagePos[0], e.pagePos[1]);
  } else {
    canvasContextMenu.context = {
      // Must set context before showing menu
      viewer: viewer,
    };

    canvasContextMenu.show(e.pagePos[0], e.pagePos[1]);
  }

  e.event.preventDefault();
});
