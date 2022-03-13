<template>
<b-row>
  <b-col md="12">
    <div style="float: left; margin-bottom: 20px; margin-left: 10px"> <button class="btn btn-primary" @click="$router.go(-1)">Go Back!</button> </div>
    <div class="table-responsive"> 
    
    <div style="width: 5%; height: 50px; float: left;"> 
           Item Id: {{this.listOfData[0].tshirtId}}  
    </div>
    <div style=" height: 50px;"> 
           Item Name: {{this.listOfData[0].name}}
    </div> 
    

      <table ref="table" class="table table-striped">
        <thead> 
          <tr>
            <th>#</th>
            <th v-for="color in listOfData[0].colors"> {{ color.value }} </th>
          </tr>
        </thead>
    
        <tbody>

        <tr v-for="fabric in listOfData[0].fabrics" > 
          {{ fabric.value }}
            <td style="height: 100px;" v-for = "color in listOfData[0].colors" >
              <div v-if="tshirt.fabricId == fabric.id && tshirt.colorId == color.id" v-for="tshirt in listOfData[0].tshirtImages"> 
                
                <img style="width: 50px; height:50px;" v-bind:src="imageEndpoint + tshirt.imagePath" />
                <button class="deleteButton" @click="deleteImage(tshirt.id)">-</button>
              </div>

              <div class="image-upload">
                <input  class="file-input"  type="file" @change="uploadFile(fabric.id,color.id)" ref="file" v-bind:fabricId="fabric.id" v-bind:colorId="color.id" />
              </div>
              
            </td>
            
        </tr>
        
        
       
      </tbody>
    
    </table>

     
</div>
  </b-col>
</b-row>

  
</template>
<script>
import TshirtService from '@/api-services/tshirt.service';

export default {
  name: 'TshirtUpdate',
  data() {
    return {
      images: undefined,
      listOfData: [],
      directory: '',
      imageEndpoint: ''  
    };
  },
  created() {
    TshirtService.get(this.$router.currentRoute.params.id).then((response) => {
      this.listOfData = response.data;
      this.imageEndpoint = 'https://localhost:44315/'
    });
  },
  methods: {
     uploadFile(fabricId,colorId) {
       this.getFile(fabricId,colorId);
       if(this.images != undefined && this.images != "") {
        
        const formData = new FormData();
        formData.append('TshirtId', this.listOfData[0].tshirtId)
        formData.append('ColorId', colorId)
        formData.append('FabricId', fabricId)
        formData.append('ImagePath','')
        formData.append('Image', this.images);

        TshirtService.addImage(formData).then(() => {
           TshirtService.get(this.$router.currentRoute.params.id).then((response) => {
          this.listOfData = response.data;
          
        });
        });
       }
        
      },
      deleteImage(id) {
        
        TshirtService.delete(id).then(()=>{
  TshirtService.get(this.$router.currentRoute.params.id).then((response) => {
          this.listOfData = response.data;
        });
        });
      
          
      },
      getFile(fabricId,colorId){
        let fileList = this.$refs.file;

        for(let i=0;i<fileList.length;i++){

          let colorId2=fileList[i].getAttribute("colorId").toString();
          let fabricId2=fileList[i].getAttribute("fabricId").toString();

          if((colorId==colorId2)&&(fabricId==fabricId2)){
            this.images = fileList[i].files[0];
            return;
          }
        }
      }
      
  }
};
</script>

<style>
.deleteButton{
background-color:transparent;
border:none;
border-radius:50px;
}

.deleteButton:hover{
background-color:red;
}
</style>