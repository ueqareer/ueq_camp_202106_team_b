<template>
  <div class="button">
    <a :href="to">{{description}}</a>
  </div>
</template>

<script>
export default {
  name: "TheButton",
  props: ['to', 'description'],
}
</script>

<style lang="scss" scoped>
.button {
  width: 150px;
  height: 50px;
  background: rgb(35, 31, 32);
  opacity:0.3;
  display: flex;
  flex-direction: column;
  justify-content: center;
  &:hover{
    opacity : 1;
    transition: opacity 0.5s ease;
  }
  a {
    text-decoration: none;
    color: white;
    font-weight: bold;
  }

}
</style>