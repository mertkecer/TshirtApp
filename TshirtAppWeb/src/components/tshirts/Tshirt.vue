<template>
  <tr>
    
                <td>{{ tshirt.id }}</td>
                <td>{{ tshirt.name }}</td>
                <td>{{ tshirt.numberOfColor }}</td>
                <td>{{ tshirt.numberOfFabric }}</td>
                <td>{{ tshirt.numberOfImage }}</td>
    <td>
      <b-button
        variant="success"
        @click="onUpdateClick">Update</b-button>
    </td>
    
  </tr>
</template>
<script>
export default {
  name: 'Tshirt',
  props: [ 'tshirt' ],
  methods: {
    onUpdateClick() {
      this.$emit('update', this.tshirt.id);
    }
  }
};
</script>