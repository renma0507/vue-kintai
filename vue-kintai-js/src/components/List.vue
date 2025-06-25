
<script setup>
import { ref, computed ,onMounted} from 'vue'
import axios  from 'axios'

// 社員データ
const employees = ref([])

const selectedName = ref('')

const getData = async () => {
  try{
  const res = await axios.get('https://localhost:55925/vue-kintai / User')
  employees.value = res.data.$values//結果を表示用に代入
  console.log('データの取得に成功しました:', employees.value)
} catch (error) {
  console.error('データの取得に失敗しました:', error)
  }

}

const selectedEmployee = computed(() => {
  if (!Array.isArray(employees.value)) return null
  return employees.value.find(emp => emp.name === selectedName.value)
})

onMounted(getData)
</script>

<template>
  <div class="employee-select">
    <h1>社員リスト</h1>
    <div class="custom-select-wrapper">
      <select v-model="selectedName" size="10">
        <option v-for="emp in employees" :key="emp.id" >
          {{ emp.name }}
        </option>
      </select>
    </div>
    <div v-if="selectedEmployee" class="employee-info">
      <p>雇用形態: {{ selectedEmployee.name }}</p>
    </div>
  </div>

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
