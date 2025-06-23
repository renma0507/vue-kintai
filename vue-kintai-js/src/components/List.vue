<template>
  <div class="employee-select">
    <h1>社員リスト</h1>
    <div class="custom-select-wrapper">
      <select v-model="selectedName" size="10">
        <option v-for="emp in employees" :key="emp.employee" :value="emp.name">
          {{ emp.name }}
        </option>
      </select>
    </div>
    <div v-if="selectedEmployee" class="employee-info">
      <p>雇用形態: {{ selectedEmployee.employee }}</p>
    </div>
  </div>
</template>

<script setup>
import { ref, computed } from 'vue'

// 社員データ
const employees = ref([
  { name: '山田 太郎',employee: '正社員' },
  { name: '山田 太郎',employee: '正社員' },
  { name: '山田 太郎',employee: '正社員' },
  { name: '佐藤次郎',employee: 'アルバイト' },
  { name: '山田 太郎',employee: '正社員' },
  { name: '山田 太郎',employee: '正社員' },
  { name: '山田 太郎',employee: '正社員' },
  { name: '山田 太郎',employee: '正社員' },

])

const selectedName = ref('')

const selectedEmployee = computed(() =>
  employees.value.find(emp => emp.name === selectedName.value)
)
</script>

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
  background-color: gray;
  border-right: 2px solid #f9f9f9;
  padding: 1rem;
  box-sizing: border-box;
  overflow-y: auto;
}

.custom-select-wrapper select {
  width: 100%;
  height: 100%;
  font-size: 1.2rem;
  border: 1px solid #999;
  border: 4px;
}

.employee-info {
  margin-top: 1rem;
  background-color: white;
  padding: 0.8rem;
  border: 10px solid red;
  border: 10px;
}

</style>
