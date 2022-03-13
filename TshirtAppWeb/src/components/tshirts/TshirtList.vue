<template>
  <div>
    <b-row>
      <b-col
        md="2"
        offset-md="10">
        
      </b-col>
    </b-row>
    <br>
    <b-row>
      <b-col md="12">
        <div class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <th>Item Id</th>
                <th>Item Name</th>
                <th>Number Of Colors</th>
                <th>Number Of Fabrics</th>
                <th>Number Of Images</th>
                <th>Edit Images</th>
              </tr>
            </thead>
            <tbody>
              <tshirt
                v-for="tshirt in tshirts"
                :key="tshirt.id"
                :tshirt="tshirt"
                @update="onUpdateClicked"
                />
            </tbody>
          </table>
        </div>
      </b-col>
    </b-row>
  </div>
</template>
<script>
import TshirtService from '@/api-services/tshirt.service';
import Tshirt from '@/components/tshirts/Tshirt'

export default {
  name: 'TshirtList',
  components: {
    Tshirt
  },
  data() {
    return {
      tshirts: []
    };
  },
  created() {
    TshirtService.getAll().then((response) => {
      this.tshirts = response.data;
    });
  },
  methods: {
    
    onUpdateClicked(tshirtId) {
      this.$router.push({ name: 'TshirtUpdate', params: { id: tshirtId } });
    },
   
  }
};
</script>