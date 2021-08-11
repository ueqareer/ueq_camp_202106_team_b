<template>
  <div class="button">
    <router-link :to=to>{{description}}</router-link>
  </div>
</template>

<script>
export default {
  name: "TheButton",
  props:['to','description']
}
</script>

<style lang="scss" scoped>
.button{
  width: 150px;
  height: 50px;
  background: rgba(35, 31, 32, 0.76);
  display: flex;
  flex-direction: column;
  justify-content: center;
  a{
    text-decoration: none;
    color : white;
    font-weight: bold;
  }


}
</style>