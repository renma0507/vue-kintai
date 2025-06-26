<!-- src/components/List.vue -->
<template>
  <div class="employee-select">
    <!-- custom-select-wrapper を追加 -->
    <div class="custom-select-wrapper">
      <select v-model="selectedName" size="10">
        <option
          v-for="emp in employees"
          :key="emp.id"
          :value="emp.id"
        >
          {{ emp.name }}
        </option>
      </select>
    </div>

    <!-- 選択中の社員情報を表示する場合 -->
    <div class="employee-info" v-if="selectedName !== null">
      雇用形態: {{ employees.find(e => e.id === selectedName)?.employmentType || '–' }}
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted, watch, defineEmits } from 'vue'
import axios from 'axios'

const emit = defineEmits(['update-selected'])
const employees = ref([])
const selectedName = ref(null)

onMounted(async () => {
  const res = await axios.get('https://localhost:55925/vue-kintai/User')
  // employmentType プロパティなどもある想定で
  employees.value = res.data.$values
})

watch(selectedName, id => {
  emit('update-selected', id)
})
</script>

<style scoped>
.employee-select {
  position: fixed;
  top: 0;
  left: 0;
  height: 100vh;            /* 600vh → 100vh に */
  width: 300px;
  background-color: #999;
  border-right: 2px solid #f9f9f9;
  padding: 1rem;
  box-sizing: border-box;
  overflow-y: auto;
}

/* セレクトボックス全体をフル幅に */
.custom-select-wrapper select {
  width: 100%;
  font-size: 1.2rem;
  padding: 0.5rem;
  border: 2px solid #560ba1;
  border-radius: 4px;
  color: #000;
  background: #fff;
}

/* 選択中の社員情報領域 */
.employee-info {
  margin-top: 1rem;
  background-color: #fff;
  padding: 0.8rem;
  border: 2px solid #e00;
  border-radius: 4px;
  font-size: 0.9rem;
  color: #333;
}
</style>
