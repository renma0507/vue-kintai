<template>
    <div>
        <h1>出退勤ログ</h1>
        <h1>エラーログ</h1>
    </div>
</template>

<style scoped>
body {
  margin: 0;
}
h1{
  color: #000;
}
div {
  position: fixed;            
  top: 0;
  right: 0;
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
