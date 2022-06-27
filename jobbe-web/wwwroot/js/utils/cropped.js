let CROPPED;

export function CROPPER_ACTION_BUTTON_TO_INPUT(buttonToLoad, elementToInsertedBase64,modalOpen) {
 
  const inputFile = document.querySelector(".cropped_modal input");
  
  const imgElement = document.querySelector(".cropped_modal .main img");
  const close = document.querySelector("#cropped_closed");

  buttonToLoad.onclick = () => {
    inputFile.click();
  };

  //change Input
  CROPPER_LOAD_FILE_TO_PREVIEW(inputFile, imgElement, elementToInsertedBase64,modalOpen);

  // close modal
  close.onclick = () => {
    CROPPED_SHOW()
    inputFile.value = ''
  }
}

function CROPPER_LOAD_FILE_TO_PREVIEW(inputElement, imgElement,elementToInsertedBase64,modalOpen) {
  
  inputElement.onchange = (event) => {
    const selectedFile = event.target.files[0];
    const reader = new FileReader();

    reader.onload = function (eventRead) {
      imgElement.setAttribute("src", eventRead.target.result);
      

      CROPPER_EXEC(imgElement, elementToInsertedBase64,modalOpen, inputElement);
      CROPPED_SHOW(true)
    };

    reader.readAsDataURL(selectedFile);

  };
}

function CROPPER_EXEC(ElementWhitoutImge, elementToInsertedBase64,modalOpen, inputElement) {
  inputElement.value = ''
  if (CROPPED) {
    CROPPED.destroy();
  }

  const image = ElementWhitoutImge;
  let dataX = {value:0};
  let dataY = {value:0};
  let dataHeight = {value:0};
  let dataWidth = {value:0};
  let dataRotate = {value:0};
  let dataScaleX = {value:0};
  let dataScaleY = {value:0};

  const options = {
    // aspectRatio: 16 / 9,
    preview: ".img-preview",
    ready: function (e) {
      console.log(e.type);
    },
    cropstart: function (e) {
      console.log(e.type, e.detail.action);
    },
    cropmove: function (e) {
      console.log(e.type, e.detail.action);
    },
    cropend: function (e) {
      console.log(e.type, e.detail.action);
    },
    crop: function (e) {
      var data = e.detail;

      dataX.value = Math.round(data.x);
      dataY.value = Math.round(data.y);
      dataHeight.value = Math.round(data.height);
      dataWidth.value = Math.round(data.width);
      dataRotate.value = typeof data.rotate !== "undefined" ? data.rotate : "";
      dataScaleX.value = typeof data.scaleX !== "undefined" ? data.scaleX : "";
      dataScaleY.value = typeof data.scaleY !== "undefined" ? data.scaleY : "";
    },
    zoom: function (e) {
      console.log(e.type, e.detail.ratio);
    },
  };

  CROPPED = new Cropper(image, options);

  document.querySelector("#croppSave").onclick = () => {
    GENERETE_BASE64(elementToInsertedBase64,modalOpen);
  };
}

function GENERETE_BASE64(elementToInsertedBase64,modalOpen) {
  const canvaImage = CROPPED.getCroppedCanvas();

  document.querySelector(".img-cropped-inserted").innerHTML = "";
  document.querySelector(".img-cropped-inserted").append(canvaImage);

 
  elementToInsertedBase64.setAttribute('src',document.querySelector(".img-cropped-inserted canvas").toDataURL())
  
  modalOpen.click()
  CROPPED_SHOW(false)
}

export function CROPPED_SHOW(isShow){
  const modal = document.querySelector(".cropped_modal")
  const modal_background = document.querySelector(".modal-background")

  if(isShow){
    modal.setAttribute('style','display:block')
    modal_background.setAttribute('style','display:block')
    return
  }

  modal.setAttribute('style','display:none')
    modal_background.setAttribute('style','display:none')
}

//exec
//CROPPER_ACTION_BUTTON_TO_INPUT();