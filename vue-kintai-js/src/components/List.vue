
<script setup>
import { ref, computed, onMounted, watch } from 'vue'
import axios from 'axios'
import { defineEmits } from 'vue'
const employees = ref([])
const selectedName = ref('')
const emit = defineEmits(['update-selected'])
const getData = async () => {
  try {
    const res = await axios.get('https://localhost:55925/vue-kintai/User')
    employees.value = res.data.$values
  } catch (error) {
    console.error('データ取得失敗:', error)
  }
}
const selectedEmployee = computed(() => {
  if (!Array.isArray(employees.value)) return null
  return employees.value.find(emp => emp.name === selectedName.value)
})
watch(selectedName, (newVal) => {
  emit('update-selected', newVal)
})
onMounted(getData)
</script>
<template>
  <div>
    <select v-model="selectedName" size="10" >
      <option v-for="emp in employees" :key="emp.id">{{ emp.name }}</option>
    </select>
  </div>

  <Button  />

</template>


<style scoped>
body {
  margin: 0;
}
h1{
  color: #000;
}
.employee-select {
  position: fixed;            
  top: 0;
  left: 0;
  height: 600vh;              
  width: 300px;               
  background-color: #999;
  border-right: 2px solid #f9f9f9;
  padding: 1rem;
  box-sizing: border-box;
  overflow-y: auto;
}

.custom-select-wrapper select {
  width: 100%;
  height: 100%;
  font-size: 1.2rem;
  border: 1px solid #560ba1;
  border: 4px;
}

.employee-info {
  margin-top: 1rem;
  background-color: white;
  padding: 0.8rem;
  border: 10px solid red;
  border: 10px;
}
select{
color: rgb(0, 0, 0);
}

</style>
