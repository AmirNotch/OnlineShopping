import React, { useEffect, useState } from "react";
import { Accordion, Button, Container, Icon, Menu, Table,Image } from "semantic-ui-react";
import agent from "./agent";
import { ManagerLogs } from "./models/product";

export default function ManagerPage() {
  const [Logs, setLogs] = useState<ManagerLogs[]>([]);
  
  useEffect(() => {
    agent.Products.listLogs().then(response => {
        setLogs(response);
    })
    console.log(Logs)
  }, [])
  
  var Total: ManagerLogs

  function posting(log: ManagerLogs) {
    Total = log;
    PostLog(Total)
  }

  function PostLog(log: ManagerLogs) {

    agent.Products.createLogs(log).then(() => {
        
    })
  }

    return(
  <Table>
    <Table.Header>
    <Table.HeaderCell>Товар</Table.HeaderCell>
        <Table.HeaderCell>Заказ №</Table.HeaderCell>
        <Table.HeaderCell>Стоимость</Table.HeaderCell>
        <Table.HeaderCell>Картинка</Table.HeaderCell>
        <Table.HeaderCell>Количества</Table.HeaderCell>
        <Table.HeaderCell>Адресс</Table.HeaderCell>
        <Table.HeaderCell>Карта</Table.HeaderCell>
        <Table.HeaderCell>Оплачено</Table.HeaderCell>
        <Table.HeaderCell>Состояние</Table.HeaderCell>
    </Table.Header>
    <Accordion
        fluid={true}
        as={Table.Body}
        panels={Logs.map(n => {
            return {
                key: n.id,
                class: "tr",
                title: {
                    as: Table.Row,
                    className: "",
                    children: [
                        <Table.Cell key={`${n.id}_type`}>{n.title}</Table.Cell>,
                        <Table.Cell key={`${n.id}_type`}>{n.numberOfGood}</Table.Cell>,
                        <Table.Cell key={`${n.id}_type`} >{n.cost}</Table.Cell>,
                        <Image
                        floated='left'
                        size='mini'
                        src={`/assets/categoryImages/${n.photo}.jpg` || `/assets/categoryImages/${n.photo}.jpeg`}
                        />,
                        <Table.Cell key={`${n.id}_type`}>{n.count}</Table.Cell>,
                        <Table.Cell key={`${n.id}_type`}>{n.address}</Table.Cell>,
                        <Table.Cell key={`${n.id}_type`}>{n.cardNumber}</Table.Cell>,
                        <Table.Cell style={{color: "green"}} key={`${n.id}_type`}>{n.payed}</Table.Cell>,
                        <Button onClick={() => posting(n)} positive content ='Create Activity' >
                        {n.statusManager}
                        </Button>
                        // <Table.Cell key={`${n.id}_type`}>{n.statusManager}</Table.Cell>,
                    ]
                },
                content: {
                    children: n.payed + ' --- ' + n.statusManager
                }
            };
        })}
    />
</Table>
    )
}
